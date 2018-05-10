module Navigation.Pagination.PaginationTotalNumber
open Fable.Import.Browser
open Fable.Helpers.React
open Fable.AntD

let showTotal1 total range =
  console.log(range)
  sprintf "Total %i items" total |> str

let showTotal2 total (from, ``to``) =
  sprintf "%i-%i of %i items" from ``to`` total |> str
  

let view () = 
  div [] [
    Pagination.pagination [
      Pagination.Total 85
      Pagination.ShowTotal showTotal1
      Pagination.PageSize 20
      Pagination.DefaultCurrent 1] []
    br []
    Pagination.pagination [
      Pagination.Total 85
      Pagination.ShowTotal showTotal2
      Pagination.PageSize 20
      Pagination.DefaultCurrent 1] []
  ]
  