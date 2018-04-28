module DemoCard

open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Fable.AntD


importAll "./DemoCard.less"

module Types =
    type Tab = 
        | Demo
        | SourceCode
    with static member GetName x =  
            match x with
            | Demo -> "Demo"
            | SourceCode -> "SourceCode"

    type DemoCardModel = {
        title: string
        demo: unit->React.ReactElement
        source: string
        activeTab: Tab
    }

module View =
    open Types

    //let getsSource path = importAll "!!highlight-loader?raw=true&lang=fsharp!" + path

    let viewCode source = 
        pre [] [
               code [ ClassName "hljs fsharp"; DangerouslySetInnerHTML { __html = source} ]  []
            ]

    let OnTabChange (dispatch:Tab->unit) s  = 
        let tab = match s with
                    | "Demo" -> Demo
                    | "SourceCode" -> SourceCode
                    | _ -> Demo
        tab |> dispatch

    let root (model:DemoCardModel) dispatch =
        
        let tabs = [|
            { key = "Demo"; tab = div [] [str "demo"] }
            { key = "SourceCode"; tab = div [] [str "code"] }
        |]

        let cardBody = 
            match model.activeTab with
            | Demo -> model.demo()
            | SourceCode -> viewCode model.source

        Card.card [ 
            ClassName "demo-card"
            Card.Title  (str model.title); Card.TabList tabs; Card.OnTabChange (OnTabChange dispatch); Card.ActiveTabKey (model.activeTab |> Tab.GetName) ] [ 
            //div [Style [MaxHeight "275px"; MinHeight "275px"; Overflow "Auto"  ]] [
            div [] [
                    cardBody
                ]
        ]