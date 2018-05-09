module Navigation.Dropdown.DropdownClickEvent
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let message = Message.message
let onClick = (fun (x:Menu.ClickParam) -> message.info("Click on item " + x.key))

let menu = 
  Menu.menu [Menu.OnClick onClick] [
    Menu.item [Key "1"] [ str "1st menu item"]
    Menu.item [Key "2"] [ str "2nd menu item"]
    Menu.item [Key "3"] [ str "3rd menu item"]
  ]
let view () = 
    Dropdown.dropdown [Dropdown.Overlay menu] [
      a [ClassName "ant-dropdown-link"; Href "#"] [
        str "Hover me "
        Icon.icon [Icon.Type "down"] []
      ]
    ]