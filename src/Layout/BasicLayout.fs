module Layout.Basic

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core.JsInterop
open Fable.Import.React

open Global

open Fable.AntD


// let basicLayout model dispatch =
    
//     Layout.layout [ ]
//         [ Layout.sider [ Layout.Trigger null; Layout.Collapsed true ]
//             [ div [ ClassName "logo" ]
//                 [ Menu.menu [ Menu.Theme MenuTheme.Dark; Menu.Mode Inline; Menu.DefaultSelectedKeys ['1'] ]
//                     [ Menu.item [ HTMLAttr.Custom ("key", "1") ]
//                         [ icon [ Type "user" ] []
//                           span [ ] [ str "nav 1" ] ] 
//                       Menu.item [ HTMLAttr.Custom ("key", "2") ]
//                         [ icon [ Type "video-camera" ] []
//                           span [ ] [ str "nav 2" ] ]
//                       Menu.item [ HTMLAttr.Custom ("key", "3") ]
//                         [ icon [ Type "upload" ]
//                           span [ ] [ str "nav 3" ] ] 
//                       ] 
//                     ] 
//                 ] 
//             ]
//         ]
                