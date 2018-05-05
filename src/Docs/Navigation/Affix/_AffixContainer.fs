module Navigation.Affix.AffixContainer
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop
open Fable.Import.Browser
open Fable.AntD
let view () = 
    // div [ClassName "scrollable-container"; Ref (fun node  -> (
    //                                                           let self = jsThis
    //                                                           console.log(self);
    //                                                           self?container <- node) )] [
    //   div [ClassName "background"] [
    //     Affix.affix [Affix.Target (fun ()-> (console.log(!!jsThis:obj); !!jsThis?container:HTMLElement ))] [
    //       Button.button [Button.Type Button.Primary] [str "Fixed at the top of container"] 
    //     ]
    //   ]
    // ]
    div [ClassName "scrollable-container"] [
      div [ClassName "background"] [ ]
    ]

    