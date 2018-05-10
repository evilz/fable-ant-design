module Navigation.Pagination.PaginationSimpleMode
open Fable.AntD

let view () = 
  Pagination.pagination [
    Pagination.Simple true
    Pagination.DefaultCurrent 2
    Pagination.Total 50 ] []
  