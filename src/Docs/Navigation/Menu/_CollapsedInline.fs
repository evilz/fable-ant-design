module Navigation.Menu.CollapsedInline
open Fable.Import.Browser
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

// let toggleCollapsed _ =
//   console.log "toggleCollapsed"

let view collapsed toggleCollapsed   () = 
  
  let handleClick (e:Menu.MenuClickArgs) =
    console.log("click ", e)
    
  div [Style [Width 256];] [
    Button.button [Button.Type Button.Primary; OnClick (fun _ -> not collapsed |> toggleCollapsed)  ;Style [MarginBottom 16] ] [
      Icon.icon [Icon.Type (if collapsed then "menu-unfold" else "menu-fold")] []
    ]
    Menu.menu [ Menu.InlineCollapsed collapsed; Menu.Theme Menu.Dark; Menu.OnClick handleClick; Menu.DefaultSelectedKeys [|"1"|]; Menu.DefaultOpenKeys [|"sub1"|]; Menu.Mode Menu.Inline] [
      Menu.item [Key "1"] [Icon.icon [Icon.Type "pie-chart"] []; span [] [str "Option 1"]]
      Menu.item [Key "2"] [Icon.icon [Icon.Type "desktop"  ] []; span [] [str "Option 2"]]
      Menu.item [Key "3"] [Icon.icon [Icon.Type "inbox"    ] []; span [] [str "Option 3"]]

      Menu.subMenu [Key "sub1"; Menu.Title (span [] [Icon.icon [Icon.Type "mail"] []; span [] [str "Navigation One"]])  ] [
          Menu.item [Key "5"] [ str "Option 5"]
          Menu.item [Key "6"] [ str "Option 6"]
          Menu.item [Key "7"] [ str "Option 7"]
          Menu.item [Key "8"] [ str "Option 8"]
        ]
      Menu.subMenu [Key "sub2"; Menu.Title (span [] [Icon.icon [Icon.Type "appstore"] []; span [] [str "Navigation Two"]])  ] [
          Menu.item [Key "9" ] [ str "Option 9" ]
          Menu.item [Key "10"] [ str "Option 10"]
          
          Menu.subMenu [Key "sub3"; Menu.Title (str "Submenu")  ] [
            Menu.item [Key "11"] [ str "Option 11"]
            Menu.item [Key "12"] [ str "Option 12"]
          ]
        ]
      
      ]
  ] 
  
  