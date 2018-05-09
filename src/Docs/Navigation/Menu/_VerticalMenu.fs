module Navigation.Menu.VerticalMenu
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view () = 

  Menu.menu [Style [Width 256]; Menu.Mode Menu.Vertical] [
    Menu.subMenu [Key "sub1"; Menu.Title (span [] [Icon.icon [Icon.Type "mail"] []; str "Navigation One"])  ] [
        Menu.itemGroup [Key "g1"; Menu.Title (str "Item 1")   ] [
            Menu.item [Key "1"] [ str "Option 1"]
            Menu.item [Key "2"] [ str "Option 2"]
        ]
        Menu.itemGroup [Key "g2"; Menu.Title (str "Item 2")   ] [
            Menu.item [Key "3"] [ str "Option 3"]
            Menu.item [Key "4"] [ str "Option 4"]
        ]
      ]
    Menu.subMenu [Key "sub2"; Menu.Title (span [] [Icon.icon [Icon.Type "appstore"] []; str "Navigation Two"])  ] [
        Menu.item [Key "5"] [ str "Option 5"]
        Menu.item [Key "6"] [ str "Option 6"]
        
        Menu.subMenu [Key "sub3"; Menu.Title (str "Submenu")  ] [
          Menu.item [Key "7"] [ str "Option 7"]
          Menu.item [Key "8"] [ str "Option 8"]
        ]
      ]
    Menu.subMenu [Key "sub4"; Menu.Title (span [] [Icon.icon [Icon.Type "setting"] []; str "Navigation Three"])  ] [
        Menu.item [Key "9"] [ str "Option 9"]
        Menu.item [Key "10"] [ str "Option 10"]
        Menu.item [Key "11"] [ str "Option 11"]
        Menu.item [Key "12"] [ str "Option 12"]
      ]
  ]