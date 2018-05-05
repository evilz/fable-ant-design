module Navigation.Breadcrumb.BreadcrumbWithIcon
open Fable.Helpers.React
open Fable.AntD

let view () = 
    Breadcrumb.breadcrumb [] [
      Breadcrumb.item [Breadcrumb.Href "" ] [Icon.icon [Icon.Type "home"] [] ]
      Breadcrumb.item [Breadcrumb.Href "" ] [
        Icon.icon [Icon.Type "user"] []
        span [] [str "Application List"] ]
      Breadcrumb.item [] [str "An Application" ]
    ]