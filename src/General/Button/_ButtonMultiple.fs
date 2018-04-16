module General.Button.ButtonMultiple
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view ()=

    let menu =
     Menu.menu [OnClick Fable.Import.Browser.console.log] [
         Menu.item [Key "1"] [str "1st item"]
         Menu.item [Key "2"] [str "2nd item"]
         Menu.item [Key "3"] [str "3rd item"]
     ]


    div [] [
        Button.button [Button.Type Button.Primary] [str "primary"]
        Button.button [] [str "secondary"]
        Dropdown.dropdown [Dropdown.Overlay menu] [
             Button.button [] [str "Actions "; Icon.icon [Icon.Type "down"] []]
        ]
    ]