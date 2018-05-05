module Navigation.Affix.AffixCallback
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.AntD

let view () = 
    div [] [
      Affix.affix [Affix.OffsetTop 120; Affix.OnChange (fun affixed -> console.log(affixed))  ] 
                  [ Button.button [] [str "120px to affix top"] ]
    ]
    