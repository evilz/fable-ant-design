module Navigation.Dropdown.DropdownHidding
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let message = Message.message
let view isVisible dispatchVisible = 

    let handleMenuClick (e:Menu.MenuClickArgs) = 
      if e.key = "3" then dispatchVisible false
      else message.info("Click on item " + e.key)
      // ()
  
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