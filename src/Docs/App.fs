module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core.JsInterop
open Types
open App.State
open Global

importAll "../../node_modules/antd/dist/antd.less"
importAll "./app.less"
let logo = importAll "./assets/img/fantle-design.png"

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD
open Fable.Import

let menuItem info =
    Menu.item [ HTMLAttr.Custom ("key", info.title) ]
              [ a [Href info.hash ] 
                  [
                    Icon.icon [ Icon.Type info.icon ] []
                    span [ ] [ str info.title ] 
                  ]
                
              ]

let subMenu icon title pages = 
  Menu.subMenu [Menu.SubMenuProps.Title (a [] [Icon.icon [Type icon] []; span [] [str title] ] )]
               [ for p in pages -> p |> getMenuInfo |> menuItem ]


let menuSider menuCollapsed currentPage dispatch =
  Layout.sider [ Layout.OnCollapse (fun args -> fun t ->
    Browser.console.log (sprintf "%A %A" args t) |> ignore
    (SiderMsg (args) |> dispatch )); 
    Layout.Collapsible true; Layout.Collapsed menuCollapsed; Layout.Width 256; Layout.Breakpoint Layout.SiderBreakpoint.LG; Layout.Trigger null ] [
        div [ Style [ Height "64px"; Position "relative"; LineHeight "64px"; PaddingLeft "24px"; Transition "all .3s"; Background "#002140"; Overflow "hidden"] ] [ 
            a [Href "/#"; Style [ ]] [
              img [Src logo; Style [ Height "32px";] ]
              h1 [ Style [Display "inline-block"; VerticalAlign "middle";  CSSProp.Color "#fff"; FontSize "20px"; Margin "0 0 0 12px"; FontFamily "\"Myriad Pro\",\"Helvetica Neue\",Arial,Helvetica,sans-serif"; FontWeight 600]] [str "Fable Ant Design"]
            ]
          ]
        Menu.menu [ Menu.Theme Menu.Dark; Menu.Mode Menu.Inline; Menu.SelectedKeys [|(getMenuInfo currentPage).title |]; ]
              [ Home |> getMenuInfo |> menuItem
                subMenu "calculator" " General" [
                    Page.Button
                    Page.Icon
                  ]

                subMenu "layout" " Layout" [
                    Page.Grid
                    Page.Layout
                  ]

                subMenu "logout" " Navigation" [
                    Page.Affix
                    Page.Breadcrumb
                    Page.Dropdown
                    Page.Menu
                    Page.Pagination
                    Page.Steps
                  ]
                 
              ] 
      ]

let header menuCollapsed dispatch = 
  Layout.header [ Style [Background "white"; Padding "0"] ]
          [ Icon.icon [ ClassName "trigger";  
                        Icon.Type (if menuCollapsed then "menu-unfold" else "menu-fold");   
                        OnClick (fun _ -> (SiderMsg (not menuCollapsed) |> dispatch )); 
                        Style [ FontSize "18px"; LineHeight "64px"; Padding "0 24px"; Cursor "pointer"; Transition "color .3s";]
                      ] [ ]
          ]


let root model dispatch =

  let pageHtml =
    function
    | Page.Home -> Home.View.root model.home (HomeMsg >> dispatch)
    | Page.Button -> General.Button.View.root model.button (ButtonMsg >> dispatch)
    | Page.Icon -> General.Icons.View.root model.icons (IconsMsg >> dispatch)
    | Page.Grid -> Layout.Grid.View.root model.grid (GridMsg >> dispatch)
    | Page.Layout -> Layout.Layout.View.root model.layout (LayoutMsg >> dispatch)
    | Page.Affix -> Navigation.Affix.View.root model.affix (AffixMsg >> dispatch)
    | Page.Breadcrumb -> Navigation.Breadcrumb.View.root model.breadcrumb (BreadcrumbMsg >> dispatch)
    | Page.Dropdown -> Navigation.Dropdown.View.root model.dropdown (DropdownMsg >> dispatch)
    | Page.Menu -> Navigation.Menu.View.root model.menu (MenuMsg >> dispatch)
    | Page.Pagination -> Navigation.Pagination.View.root model.pagination (PaginationMsg >> dispatch)
    | Page.Steps -> Navigation.Steps.View.root model.steps (StepsMsg >> dispatch)
    | _ -> Home.View.root model.home (HomeMsg >> dispatch)

  div [] [ 
    Layout.layout [] [
      menuSider model.menuCollapsed model.currentPage dispatch
      Layout.layout [] [
        header model.menuCollapsed dispatch
        
        Layout.content [ Style [ Margin "24px 16px"; Padding 24; Background "#fff"; MinHeight 700 ] ]
          [
            pageHtml model.currentPage
            
          ]
        Layout.footer [] [str ""]
       ]
    ]
  ]
  
     

open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
|> Program.run
