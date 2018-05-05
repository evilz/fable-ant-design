module Navigation.Affix.BasicAffix
open Fable.Helpers.React
open Fable.AntD

let view () = 
    div [] [
      Affix.affix [] [ Button.button [Button.Type Button.Primary] [str "Affix top"] ]
      br []
      Affix.affix [Affix.OffsetBottom 0 ] [ Button.button [Button.Type Button.Primary] [str "Affix bottom"] ] 
    ]
    