module Navigation.Dropdown.DropdownContextMenu
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let menu = 
  Menu.menu [] [
    Menu.item [Key "1"] [ str "1st menu item"]
    Menu.item [Key "2"] [ str "2nd menu item"]
    Menu.item [Key "3"] [ str "3rd menu item"]
  ]

let view () = 
    Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.Trigger [|Dropdown.ContextMenu|] ] [
      span [ ] [ str "Right Click on Me " ]
    ]