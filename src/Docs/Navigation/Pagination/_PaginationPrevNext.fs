module Navigation.Pagination.PaginationPrevNext
open Fable.Helpers.React
open Fable.AntD

let itemRender current ``type`` originalElement =
  match ``type`` with
  | Pagination.Prev -> a [] [str "Previous"]
  | Pagination.Next -> a [] [str "Next"]
  | _ -> originalElement


let view () = 
  Pagination.pagination [
    Pagination.Total 500
    Pagination.ItemRender itemRender 
    ] []