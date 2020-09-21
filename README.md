# Hobodream framework

Hobodream is a set of Unity tools created by Neogoma. The objective is to let our designers to prototype their experiences with a minimum help from developers as well as standardizing systems for using Unity Bundle system efficiently.

This framework is useful if:
- You are a developer and are looking for a quick implementation of an Observer design pattern in unity
- You are using other Hobodream frameworks (this framework is the base of all the other frameworks we are developing) 

# Compatibility

Unity 2019.4.x or higher

# Common useful components

## Observer system

#### Overview
In order to allow classes to quickly communicate with each other and avoid using calls like **BroadcastMessage** we decided to use an Observer pattern approach.
In our framework, the classes that notify are implementing the interface **_IInteractiveElement_** and the classes that are listening to the changes are implementing **_IInteractiveElementListener_**.
The communications between **_IInteractiveElement_** and **_IInteractiveElementListener_** are using an **_IInteractionEvent_** object to communicate with each other.
All the communications are using an **_InteractiveEventAction_** to qualify what type of interaction happened (is it a click ? a double click ? a success ? a failure ?).

### Base implementations
Note that **_IInteractiveElement_** and **_IInteractionEvent_** have their own basic implementations, respectively **_AbstractInteractive_**, **_AbstractNonMonoInteractive_** and **_BaseInteractionEvent_**. 
- **_AbstractInteractive_** : is an abstract class implementing a basic Observer pattern logic. It implements all the methods in **_IInteractiveElement_** has been created to add more to a monobehavior script. 
- **_AbstractNonMonoInteractive_** : is also an abstract class implementing **_IInteractiveElement_** but it can be used on standard C# classes rather than monobehaviors
- **_BaseInteractionEvent_** : Is the basic implementation of **_IInteractionEvent_**, the class is a standard c# class. You can extend it to add more data to communicate between your classes.

**NOTE** An **_IInteractiveElement_** can trigger multiple type of Events and a **_IInteractiveElementListener_** can listen to multiple type of events. 

### Example
The example is located on the scene Scene\BaseListenerScene.
- **_BasicInteractive_** is a basic implementation of **_AbstractInteractive_** that will register 2 **_IInteractiveElementListener_**. It will also trigger an event depending on which button you press: if you press SPACE, a success event will be triggered. If you press C, a click event will be triggered.
- **_SuccessListener__** is a **_IInteractiveElement_** that will only react to **SUCCESS** type events. When a success event will be detected it will display a message in the console
- **SuccessAndClickListener** is a **_IInteractiveElement_** that will react to **SUCCESS** AND **CLICK** type events. When a success OR click will be detected it will display a different message in the console

## Networking system

### Overview
The unity networking system works great but we wanted to regroup all the networking calls into one class and have different management depending on which data you download (text, image, file...). We also implemented an observer pattern for this system.
Each download type has its own **IHTTPNotifier** which requires a specific **IRequestHandlerListener**:
- **IJSonRequestListener**, is used for requests that expect text/json results
- **ITextureDownloadListener** is used for requests that expect a texture result
- **IFileDownloaderListener** is used for requests that expect a file results
- **IBundleDownloadListener** is used for the download of Unity Asset bundles 

The main access is the **_NetworkProvider_**, it is a class that will give you access to the different download interfaces via **GetDefaultHTTPNotifier<L>()**. You need one on your scene as well as a **_CoroutineManager_**
You can directly access the provider via a singleton
`var provider=NetworkProvider.Instance;`

Once you have access to the provider you can require whatever connector you want based on the listener type. 
If you want a connector that will require text/json data you can call the **GetDefaultHTTPNotifier** with **IJSonRequestListener** as a type like this
`IHTTPConnector<string, IJSonRequestListener> connector = provider.GetDefaultHTTPNotifier<IJSonRequestListener>();`

### Basic operations
You can register a listener to a connector by using the __AddListener__ method. When you add a listener you need to provide an object and a key. The key will be used to decide when to call the listener.

**NOTE**: A listener can listen to multiple keys but in this case you need to add it manually every time.
You can request URL via the __RequestURL__ method. If you don't specify any listener Key then the request will happen without notifying anybody. If the request has listeners then the listener methods will be called depending on the result.

**NOTE**: When using the system you can have a warning "No JWT token", it's because our implementation is design to work with a Laravel API using bearer tokens for authentification.

### Examples

The example is located on the scene Scene/BaseNetWorkingScene.
- **_TextRequestExample_** is an example on how to work with a JSON/Text download
- **_ImageRequestExample_** is an example on how to work with a Texture download

### Using your own REST API
During our development all our database calls were relying on a REST API so we decided to integrate this into the framework too so you guys can standardize your builds without keeping changing the URL everywhere in your app.
You can create a database configuration via the menu **Tools/Neogoma/Create API Configuration**. It will create a **dbconfig.json** file in your StreamingAsset folder.
The URL facade is in **__ConstantUtils.BASE_URL__**. Please note that the variable is not available until **ConstantUtils.DB_READY** is true
- **Local url** is your local development environment
- **Preproduction URL** is your preproduction environment
- **Development url** is your development environment
- **Production url** is your production environment
**NOTE** The production url is only use when you do a Release build (Developmement build unchecked in the build settings)

There are also 2 booleans values
- **Use local** by checking this you will force the system to use the Local environemt doesn't matter the build configuration or other values checked
- **Use preprod** will force the system to use the preprod environment on a development build

Once the file is created you can modify the generated json file as you wish.

## Localization scripts
The localization component is used to change the language of your app based on phone settings or user choice. You just need to add a **_LanguageManager_** in your scene and add a **_LanguageLoader_** to EVERY text you want translated in your app. 

### Using the tool to generate the JSON file
You can generate the localization files with the menu **Tools/Neogoma/Language manager systems**.
It will look for every **Text** components in your scene and you just need to check on every Text you want to translate.
Select the language you want to have a localization for and click on "Add the language loader". It will add a **_LanguageLoader_** component that has a **Text Key** filled by default with the hierarchy of the text. You can change the value if you want.
The system will generate a JSON file with a list of  key/values. The key is used to identify which text element will use the content. The keys CAN be shared, so if a key is used by multiple items they will all share the same value.

### Providing values for your app which are not on UI (Console messages, Datas translations...)
We are aware that sometimes string values are used in the code but not on the UI, for this purpose we created the interface **_ISourceCodeLanguageProvider_**. This interface allow monobehavior classes to define keys to add on the file.
The keys needs to be provided via the **_GetAllProvidedKeys__** methods. Once the key is setup it will also appear on the language manager window.

## Basic scripts
We have a bunch of basic scripts for easy setup and prototyping:
- **BaseCollisionInteractive** which is an interactive that triggers collisions events
- **BaseTriggerInteractive** which is an interactive that triggers trigger events
- **Shoot** which is a basic shooting script that will start from camera if no shoot origin was specified
- **TextIncrement** that can makes it easy to increment a text
- **SimpleCommonButton** is a button script that can trigger different type of events depending on your choice

# TODO
- Complete documentation with non critical components
- Add more examples
