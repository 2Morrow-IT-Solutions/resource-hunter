# Resource Hunter
### Version 1.0

## Description

Convert Excel files with multiple language translations to proper formats used for Android (`.xml`) and IOS (`.strings`).

This application is designed to help mobile developers regarding the needs for providing the created content in other languages as well.

## How It Works

  Initially, the user will need to import the excel file in the project folder. When the program is executed, the console app will be opened, scanning the excel document, and showing all the languages that have been detected.
  
  From this point the user can select the desired conversion option. After the process is done, you have to go after the Output folder and check the results. The output files will be organised into two separatley folders, Android for `.xml` files, and IOS for `.strings` files. Further, each folder will contain a sub-folder for every language generated from the excel document, inside of it being found the expected file.

## Installation

Firstly, you will need to setup your excel file, following the next steps.

The Excel file must include :

- first column with the keywords.
- second column with your standard language.
- next columns with the desired translations. You can insert as many as you wish.
- on the top of each column you need to have the language name.
- you should rename the file as "Languages.xlsx".
</br>
</br>

> *Note*: </br>
  Regarding the translations in excel, we recommend as a starting point to use Office Add-ins -> Functions Translator, or "=GOOGLETRANSLATE()" formula, in Google Sheets. 
  </br>
  </br>
  You can read more about the Functions Translator here:
  [Excel Functions Translator](https://support.microsoft.com/en-gb/office/excel-functions-translator-f262d0c0-991c-485b-89b6-32cc8d326889)
  </br>
  </br>
  You can read more about the GOOGLETRANSLATE function here:
  [GOOGLETRANSLATE](https://support.google.com/docs/answer/3093331?hl=en)


## Usage

1. Download the latest release from [Github](https://github.com/2Morrow-IT-Solutions/resource-hunter/releases)
2. Add the excel file to the following folder Path: \ResourceHunter\bin\Release\net7.0\Input
3. Run the app and choose one converting option (*xml for Android, .strings for IOS, or both)
4. After the process is done, you can find the converted files, for each languages, in the Output folder.

## Technologies used

- EPPlus (4.5.3) - Excel spreadsheets library for .NET

  <https://www.epplussoftware.com/>

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.
