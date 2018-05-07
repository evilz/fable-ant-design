module Navigation.Dropdown.DropdownHidding
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view isVisible dispatchVisible = 

    let handleMenuClick (e) = if e.key = "3" then dispatchVisible false
  
    let handleVisibleChange  (flag) = dispatchVisible flag

    let menu = 
      Menu.menu [Menu.OnClick handleMenuClick] [
        Menu.item [Key "1"] [ str "Clicking me will not close the menu."]
        Menu.item [Key "2"] [ str "Clicking me will not close the menu also."]
        Menu.item [Key "3"] [ str "Clicking me will close the menu"]
      ]

    Dropdown.dropdown [Dropdown.Overlay menu; Dropdown.OnVisibleChange handleVisibleChange; Dropdown.Visible isVisible] [
      a [ClassName "ant-dropdown-link"; Href "#"] [
        str "Hover me "
        Icon.icon [Icon.Type "down"] []
      ]
    ]