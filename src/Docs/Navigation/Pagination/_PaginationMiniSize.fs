module Navigation.Pagination.PaginationMiniSize
open Fable.AntD
open Fable.Helpers.React

let showTotal total _ =
  sprintf "Total %i items" total |> str

let view () = 
  div [] [
    Pagination.pagination [
      Pagination.Size Pagination.Small
      Pagination.Total 50 ] []
    br []
    Pagination.pagination [
      Pagination.Size Pagination.Small
      Pagination.Total 50
      Pagination.ShowQuickJumper true
      Pagination.ShowSizeChanger true ] []
    br []
    Pagination.pagination [
      Pagination.Size Pagination.Small
      Pagination.Total 50
      Pagination.ShowTotal showTotal ] []
  ]
  