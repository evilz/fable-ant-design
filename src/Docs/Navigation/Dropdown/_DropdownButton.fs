module Navigation.Dropdown.DropdownButton
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD
open Fable.Import.Browser

let handleButtonClick (e:Fable.Import.React.MouseEvent) = 
  Message.message.info("Click on left button.")
  console.log("click left button", e)


let handleMenuClick (e:Menu.ClickParam) =
  Message.message.info("Click on menu item.")
  console.log("click", e)


let menu = 
  Menu.menu [Menu.OnClick handleMenuClick] [
    Menu.item [Key "1"] [ str "1st menu item"]
    Menu.item [Key "2"] [ str "2nd menu item"]
    Menu.item [Key "3"] [ str "3rd menu item"]
  ]

let view () = 
  div [] [
    Dropdown.button [Dropdown.Overlay menu; OnClick handleButtonClick] [ str "Dropdown" ]
    
    Dropdown.button [Dropdown.Overlay menu; OnClick handleButtonClick; Disabled true; Style [MarginLeft 8]] [ str "Dropdown" ]
    
    Dropdown.dropdown [Dropdown.Overlay menu] [
      Button.button [ ] [ 
        str "Button"
        Icon.icon [Icon.Type "down" ] []
      ]
    ]
  ]