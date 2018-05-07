module Navigation.Dropdown.DropdownOtherElements
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let link href text =
  a [Target "_blank"; Rel "noopener noreferrer"; Href href ] [str text ] 

let menu = 
  Menu.menu [] [
    Menu.item [Key "0"] [ link "http://www.alipay.com/" "1st menu item"]
    Menu.item [Key "1"] [ link "http://www.taobao.com/" "2nd menu item"]
    Menu.divider []
    Menu.item [Key "3"; Menu.Disabled true] [ str "3rd menu item（disabled)"]
  ]
let view () = 
    Dropdown.dropdown [Dropdown.Overlay menu] [
      a [ClassName "ant-dropdown-link"; Href "#"] [
        str "Hover me "
        Icon.icon [Icon.Type "down"] []
      ]
    ]