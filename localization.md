## Overview
The localization component is used to change the language of your app based on phone settings or user choice. You just need to add a **_LanguageManager_** in your scene and add a **_LanguageLoader_** to EVERY text you want translated in your app. 

### Using the tool to generate the JSON file
You can generate the localization files with the menu **Tools/Neogoma/Language manager systems**.
It will look for every **Text** components in your scene and you just need to check on every Text you want to translate.
Select the language you want to have a localization for and click on "Add the language loader". It will add a **_LanguageLoader_** component that has a **Text Key** filled by default with the hierarchy of the text. You can change the value if you want.
The system will generate a JSON file with a list of  key/values. The key is used to identify which text element will use the content. The keys CAN be shared, so if a key is used by multiple items they will all share the same value.

### Providing values for your app which are not on UI (Console messages, Datas translations...)
We are aware that sometimes string values are used in the code but not on the UI, for this purpose we created the interface **_ISourceCodeLanguageProvider_**. This interface allow monobehavior classes to define keys to add on the file.
The keys needs to be provided via the **_GetAllProvidedKeys__** methods. Once the key is setup it will also appear on the language manager window.