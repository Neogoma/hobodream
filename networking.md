## Overview
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

## Basic operations
You can register a listener to a connector by using the __AddListener__ method. When you add a listener you need to provide an object and a key. The key will be used to decide when to call the listener.

**NOTE**: A listener can listen to multiple keys but in this case you need to add it manually every time.
You can request URL via the __RequestURL__ method. If you don't specify any listener Key then the request will happen without notifying anybody. If the request has listeners then the listener methods will be called depending on the result.

**NOTE**: When using the system you can have a warning "No JWT token", it's because our implementation is design to work with a Laravel API using bearer tokens for authentification.

## Examples

The example is located on the scene __Scene/BaseNetWorkingScene__.
- **_TextRequestExample_** is an example on how to work with a JSON/Text download
- **_ImageRequestExample_** is an example on how to work with a Texture download

## Using your own REST API
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

Once the file is created you can modify the generated json file as you wish.s