module Navigation.Menu.TopNavigation
open Fable.Import.Browser
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

// model
let current = "mail" 
let dispatchCurrentMenu s = ()

let view () = 
  
  let handleClick (e:Menu.MenuClickArgs) =
    console.log("click ", e)
    dispatchCurrentMenu e.key
    
  
  Menu.menu [Menu.OnClick handleClick; Menu.SelectedKeys [|current|]; Menu.Mode Menu.Horizontal] [
    Menu.item [Key "mail"] [ Icon.icon [Icon.Type "mail"] []; str "Navigation One"]
    Menu.item [Key "app"; Disabled true] [ Icon.icon [Icon.Type "appstore" ] []; str "Navigation Two"]

    Menu.subMenu [Menu.Title (span [] [Icon.icon [Icon.Type "setting"] []; str "Navigation Three - Submenu"])  ] [
        Menu.itemGroup [Menu.Title (str "Item 1")   ] [
            Menu.item [Key "setting:1"] [ str "Option 1"]
            Menu.item [Key "setting:2"] [ str "Option 2"]
        ]
        Menu.itemGroup [Menu.Title (str "Item 2")   ] [
            Menu.item [Key "setting:3"] [ str "Option 3"]
            Menu.item [Key "setting:4"] [ str "Option 4"]
        ]
      ]
    Menu.item [Key "alipay"] [ 
        a [Href "https://ant.design"; Target "_blank"; Rel "noopener noreferrer" ] [str "Navigation Four - Link"]
    ]
  ]