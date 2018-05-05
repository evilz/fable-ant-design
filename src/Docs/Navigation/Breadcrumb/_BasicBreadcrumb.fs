module Navigation.Breadcrumb.BasicBreadcrumb
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view () = 
    Breadcrumb.breadcrumb [] [
      Breadcrumb.item [] [str "Home" ]
      Breadcrumb.item [] [ a [Href ""] [str "Application Center"] ]
      Breadcrumb.item [] [ a [Href ""] [str "Application List"] ]
      Breadcrumb.item [] [str "An Application" ]
    ]