module Navigation.Dropdown.DropdownCascading
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let link href text =
  a [Target "_blank"; Rel "noopener noreferrer"; Href href ] [str text ] 

let menu = 
  Menu.menu [] [
    Menu.item [] [ str "1st menu item"]
    Menu.item [] [ str "2nd menu item"]
    Menu.subMenu [Menu.Title (str "sub menu")] [
      Menu.item [] [ str "3rd menu item"]
      Menu.item [] [ str "4th menu item"]
    ]
    Menu.subMenu [Menu.Title (str "disabled sub menu"); Disabled true] [
      Menu.item [] [ str "5d menu item"]
      Menu.item [] [ str "6th menu item"]
    ]
  ]
let view () = 
    Dropdown.dropdown [Dropdown.Overlay menu] [
      a [ClassName "ant-dropdown-link"; Href "#"] [
        str "Hover me "
        Icon.icon [Icon.Type "down"] []
      ]
    ]