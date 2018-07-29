namespace Fable.AntD 

open Fable.Import
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
/// Cascade selection box.
module Cascader = 
    
    /// Specifies the size of the cascader element
    type CascaderSize = Small | Large

    /// Defines a single option for the user to choose from the cascader
    type CascaderValue = {
        Value : string 
        Label : string 
        Children : CascaderValue list
    }

    /// expand current item when click or hover
    type ExpandTrigger = Click | Hover 

    /// Defines the size the of cascader
    let Size (size: CascaderSize) = 
        match size with 
        | Small -> unbox<IProp> ("size", "small")
        | Large -> unbox<IProp> ("size", "large") 
    
    /// Converts the cascader value into the object the cascader element expects
    let rec internal makeOption (value: CascaderValue) = 
        // create empty object literal
        let option = obj()
        Common.setProp "value" value.Value option
        Common.setProp "label" value.Label option 
        let children = 
          value.Children
          |> Array.ofList
          |> Array.map makeOption 
        Common.setProp "children" children option 
        option

    /// Choose what triggers the submenu's to expand, whether it is a mouse click or hover
    let ExpandOn (trigger: ExpandTrigger) = 
        match trigger with 
        | Click -> unbox<IProp> ("expandTrigger", "click")
        | Hover -> unbox<IProp> ("expandTrigger", "hover")

    /// Choose what value to render on the cascader element
    let DisplayRender (render: string list -> string) = 
        let innerRender = List.ofArray >> render 
        unbox<IProp> ("displayRender", innerRender)

    /// Whether the cascader is disabled	
    let Disabled (value: bool) = 
        unbox<IProp> ("disabled", value)

    /// The options to select from
    let Options (options : CascaderValue list) = 
        let options = Array.ofList options |> Array.map makeOption 
        unbox<IProp> ("options", options) 


    /// Initializes the components with values
    let DefaultValues (values: string list) = 
        let innerValues = Array.ofList values
        unbox<IProp> ("defaultValue", innerValues)

    /// The OnSelected handler fires when the user finishes selecting the last option and emits the path of the values of the input options as a list of strings
    let OnSelected (hanlder: string list -> unit)  = 
        let originalHandler = List.ofArray >> hanlder
        unbox<IProp> ("onChange", originalHandler)

    /// Cascade selection box.
    let inline cascader (props: IProp list) (children: React.ReactElement list): React.ReactElement =
       ofImport "Cascader" "antd" (keyValueList CaseRules.LowerFirst props) children