module Navigation.Breadcrumb.BreadcrumbSeparator
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core
open Fable.AntD

let view () = 
    Breadcrumb.breadcrumb [Breadcrumb.Separator (U2.Case1(">"))] [
      Breadcrumb.item [] [str "Home" ]
      Breadcrumb.item [] [ a [Href ""] [str "Application Center"] ]
      Breadcrumb.item [] [ a [Href ""] [str "Application List"] ]
      Breadcrumb.item [] [str "An Application" ]
    ]