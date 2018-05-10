module Navigation.Pagination.PaginationJumper
open Fable.AntD
open Fable.Import.Browser

let onChange pageNumber _ =
  console.log(pageNumber)
  

let view () = 

  Pagination.pagination [
    Pagination.ShowQuickJumper true
    Pagination.OnChange onChange
    Pagination.DefaultCurrent 2
    Pagination.Total 500 ] []