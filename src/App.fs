module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core.JsInterop
open Types
open App.State
open Global

importAll "../node_modules/antd/dist/antd.less"
let logo = importAll "../assets/img/fantle-design.png"

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


let menuSider menuCollapsed currentPage dispatch =
  Layout.sider [ Layout.OnCollapse (fun args -> fun t ->
    Browser.console.log (sprintf "%A %A" args t) |> ignore
    (MenuMsg (args) |> dispatch )); 
    Layout.Collapsible true; Layout.Collapsed menuCollapsed; Layout.Width 256; Layout.Breakpoint Layout.SiderBreakpoint.LG; Layout.Trigger null ] [
        div [ Style [ Height "64px"; Position "relative"; LineHeight "64px"; PaddingLeft "24px"; Transition "all .3s"; Background "#002140"; Overflow "hidden"] ] [ 
            a [Href "/#"; Style [ ]] [
              img [Src logo; Style [ Height "32px";] ]
              h1 [ Style [Display "inline-block"; VerticalAlign "middle";  CSSProp.Color "#fff"; FontSize "20px"; Margin "0 0 0 12px"; FontFamily "\"Myriad Pro\",\"Helvetica Neue\",Arial,Helvetica,sans-serif"; FontWeight 600]] [str "Fable Ant Design"]
            ]
          ]
        Menu.menu [ Menu.Theme Menu.Dark; Menu.Mode Menu.Inline; Menu.SelectedKeys [|(getMenuInfo currentPage).title |]; ]
              [ Home |> getMenuInfo |> menuItem
                Menu.subMenu [Menu.SubMenuProps.Title (a [] [
                                                              Icon.icon [Type "calculator"] []
                                                              span [] [str " General"]
                                                            ] )] 
                  [
                    General GeneralComponents.Button |> getMenuInfo |> menuItem
                    General GeneralComponents.Icon |> getMenuInfo |> menuItem
                  ]
                 
              ] 
      ]

let root model dispatch =

  let pageHtml =
    function
    // | Page.About -> Info.View.root
    // | Counter -> Counter.View.root model.counter (CounterMsg >> dispatch)
    | Home -> Home.View.root model.home (HomeMsg >> dispatch)
    | General g ->
      match g with
      | Button -> General.Button.View.root model.button (ButtonMsg >> dispatch)
      |_ -> General.Button.View.root model.button (ButtonMsg >> dispatch)
    | _ -> Home.View.root model.home (HomeMsg >> dispatch)


  div [] [ 
    Layout.layout [] [
      menuSider model.menuCollapsed model.currentPage dispatch
      Layout.layout [] 
        [
        Layout.header [ Style [Background "white"; Padding "0"] ]
          [ Icon.icon [ ClassName "trigger";  
                        Icon.Type "menu-unfold";   
                        OnClick (fun _ -> (MenuMsg (not model.menuCollapsed) |> dispatch )); 
                        Style [ FontSize "18px"; LineHeight "64px"; Padding "0 24px"; Cursor "pointer"; Transition "color .3s";]
                      ] [ ] 
          ]
        Layout.content [ Style [ Margin "24px 16px"; Padding 24; Background "#fff"; MinHeight 700 ] ]
          [
            pageHtml model.currentPage
            
          ]
        Layout.footer [] [str "footer"]
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
