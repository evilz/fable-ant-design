namespace Fable.AntD

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Breadcrumb =

    type Route = { path: string; breadcrumbName: string;}
    
    type BreadcrumbProps =
        | ItemRender of (Route * obj * Route[] * string[] -> React.ReactNode)
        | Params of obj
        | Routes of obj[]
        | Separator of U2<string, React.ReactNode>
        interface Fable.Helpers.React.Props.IProp

    type BreadcrumbItemProps =
        | Href of string
        interface Fable.Helpers.React.Props.IProp

    let inline breadcrumb  (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Breadcrumb" "antd" (keyValueList CaseRules.LowerFirst props) children


    
    let inline item (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Breadcrumb.Item" "antd" (keyValueList CaseRules.LowerFirst props) children