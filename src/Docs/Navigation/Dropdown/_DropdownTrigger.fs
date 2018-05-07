module Navigation.Dropdown.DropdownTrigger
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
    Menu.item [Key "3"] [ link "http://www.tmall.com/" "3rd menu item"]
  ]

let view () = 
    Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Trigger [|Dropdown.Click|] ] [
      a [ClassName "ant-dropdown-link"; Href "#"] [
        str "Click me "
        Icon.icon [Icon.Type "down"] []
      ]
    ]