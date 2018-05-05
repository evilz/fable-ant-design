module Navigation.Affix.BasicAffix
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.AntD

let view () = 
    div [] [
      Affix.affix [] [ Button.button [Button.Type Button.Primary] [str "Affix top"] ]
      div [ Style [Height 800] ] []
      Affix.affix [Affix.OffsetBottom 0 ] [ Button.button [Button.Type Button.Primary] [str "Affix bottom"] ] 
    ]
    