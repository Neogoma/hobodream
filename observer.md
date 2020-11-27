## Overview
In order to allow classes to quickly communicate with each other and avoid using calls like **BroadcastMessage** we decided to use an Observer pattern approach.
In our framework, the classes that notify are implementing the interface **_IInteractiveElement_** and the classes that are listening to the changes are implementing **_IInteractiveElementListener_**.

The communications between **_IInteractiveElement_** and **_IInteractiveElementListener_** are using an **_IInteractionEvent_** object to communicate with each other.
All the communications are using an **_InteractiveEventAction_** to qualify what type of interaction happened (is it a click ? a double click ? a success ? a failure ?).

## Base implementations
Note that **_IInteractiveElement_** and **_IInteractionEvent_** have their own basic implementations, respectively **_AbstractInteractive_**, **_AbstractNonMonoInteractive_** and **_BaseInteractionEvent_**. 
- **_AbstractInteractive_** : is an abstract class implementing a basic Observer pattern logic. It implements all the methods in **_IInteractiveElement_** has been created to add more to a monobehavior script. 
- **_AbstractNonMonoInteractive_** : is also an abstract class implementing **_IInteractiveElement_** but it can be used on standard C# classes rather than monobehaviors
- **_BaseInteractionEvent_** : Is the basic implementation of **_IInteractionEvent_**, the class is a standard c# class. You can extend it to add more data to communicate between your classes.

**NOTE** An **_IInteractiveElement_** can trigger multiple type of Events and a **_IInteractiveElementListener_** can listen to multiple type of events. 

## Example
The example is located on the scene __Scene\BaseListenerScene__.
- **_BasicInteractive_** is a basic implementation of **_AbstractInteractive_** that will register 2 **_IInteractiveElementListener_**. It will also trigger an event depending on which button you press: if you press SPACE, a success event will be triggered. If you press C, a click event will be triggered.
- **_SuccessListener__** is a **_IInteractiveElement_** that will only react to **SUCCESS** type events. When a success event will be detected it will display a message in the console
- **SuccessAndClickListener** is a **_IInteractiveElement_** that will react to **SUCCESS** AND **CLICK** type events. When a success OR click will be detected it will display a different message in the console