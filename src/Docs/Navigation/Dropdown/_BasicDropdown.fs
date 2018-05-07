module Navigation.Dropdown.BasicDropdown
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let link href text =
  a [Target "_blank"; Rel "noopener noreferrer"; Href href ] [str text ] 

let menu = 
  Menu.menu [] [
    Menu.item [] [ link "http://www.alipay.com/" "1st menu item"]
    Menu.item [] [ link "http://www.taobao.com/" "2nd menu item"]
    Menu.item [] [ link "http://www.tmall.com/" "3rd menu item"]
  ]
let view () = 
    Dropdown.dropdown [Dropdown.Overlay menu] [
      a [ClassName "ant-dropdown-link"; Href "#"] [
        str "Hover me "
        Icon.icon [Icon.Type "down"] []
      ]
    ]