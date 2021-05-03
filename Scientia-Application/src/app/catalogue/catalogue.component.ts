import { Component, OnInit, ElementRef, HostListener, AfterViewInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';
import { HttpClient } from '@angular/common/http';
import { SharedService } from '../shared.service'

@Component({
  selector: 'app-catalogue',
  templateUrl: './catalogue.component.html',
  styleUrls: ['./catalogue.component.css']
})
export class CatalogueComponent implements OnInit, AfterViewInit {
  @ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective;
  @ViewChild(MdbTablePaginationComponent, { static: true }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild('row', { static: true }) row: ElementRef;

  elements: any = [];
  catalogue: any = [];
  headElements = ['id', 'cover', 'title', 'author', 'date', 'type', 'genre', 'rating', 'pages', 'copies'];

  searchText: string = '';
  previous: string;

  maxVisibleItems: number = 15;

  url: string = 'https://jsonplaceholder.typicode.com/posts';
  readonly APIUrl: string = 'https://localhost:5001/api';

  constructor(private cdRef: ChangeDetectorRef, private http: HttpClient, private service: SharedService) { }

  @HostListener('input') oninput() {
    this.mdbTablePagination.searchText = this.searchText;
  }


  //Populating array which will be used as datasource
  ngOnInit(): void {
    this.refreshCatalogueList();

    // this.http.get(this.url).subscribe((data: any) => {
    //   data.forEach((el: any) => {
    //     this.elements.push({
    //       id: el.id.toString(),
    //       first: el.title,
    //       last: el.body,
    //       handle: 'Handle ' + el.id.toString()
    //     });
    //   });
    //   this.mdbTable.setDataSource(this.elements);
    // });
    // this.elements = this.mdbTable.getDataSource();
    // this.previous = this.mdbTable.getDataSource();
  }

  refreshCatalogueList() {
    this.service.getEntireCatalogue().subscribe(data => {
      this.catalogue = data;
      data.forEach((el: any) => {
        this.elements.push({
          id: el.ID.toString(),
          cover: el.BookPictureUrl,
          title: el.Title,
          author: el.Author.Name,
          date: el.PublishedDate.toString(),
          type: el.Type,
          genre: el.Genre,
          rating: el.Rating.toString(),
          pages: el.TotalPages.toString(),
          copies: el.Copies.toString()
        });
      });
      this.mdbTable.setDataSource(this.elements);
      console.log(data);
    })
    this.elements = this.mdbTable.getDataSource();
    this.previous = this.mdbTable.getDataSource();
  }

  //Pagination
  ngAfterViewInit() {
    this.mdbTablePagination.setMaxVisibleItemsNumberTo(this.maxVisibleItems);

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();
    this.cdRef.detectChanges();
  }

  // addNewRow() {
  //   this.mdbTable.addRow({
  //     id: this.elements.length.toString(),
  //     first: 'Wpis ' + this.elements.length,
  //     last: 'Last ' + this.elements.length,
  //     handle: 'Handle ' + this.elements.length
  //   });
  //   this.emitDataSourceChange();
  // }

  // addNewRowAfter() {
  //   this.mdbTable.addRowAfter(1, { id: '2', first: 'Nowy', last: 'Row', handle: 'Kopytkowy' });
  //   this.mdbTable.getDataSource().forEach((el: any, index: any) => {
  //     el.id = (index + 1).toString();
  //   });
  //   this.emitDataSourceChange();
  // }

  // removeLastRow() {
  //   this.mdbTable.removeLastRow();
  //   this.emitDataSourceChange();
  //   this.mdbTable.rowRemoved().subscribe((data: any) => {
  //     console.log(data);
  //   });
  // }

  // removeRow() {
  //   this.mdbTable.removeRow(1);
  //   this.mdbTable.getDataSource().forEach((el: any, index: any) => {
  //     el.id = (index + 1).toString();
  //   });
  //   this.emitDataSourceChange();
  //   this.mdbTable.rowRemoved().subscribe((data: any) => {
  //     console.log(data);
  //   });
  // }

  // emitDataSourceChange() {
  //   this.mdbTable.dataSourceChange().subscribe((data: any) => {
  //     console.log(data);
  //   });
  // }

  //Search
  searchItems() {
    const prev = this.mdbTable.getDataSource();

    if (!this.searchText) {
      this.mdbTable.setDataSource(this.previous);
      this.elements = this.mdbTable.getDataSource();
    }

    if (this.searchText) {
      this.elements = this.mdbTable.searchLocalDataBy(this.searchText);
      this.mdbTable.setDataSource(prev);
    }

    this.mdbTablePagination.calculateFirstItemIndex();
    this.mdbTablePagination.calculateLastItemIndex();

    this.mdbTable.searchDataObservable(this.searchText).subscribe(() => {
      this.mdbTablePagination.calculateFirstItemIndex();
      this.mdbTablePagination.calculateLastItemIndex();
    });
  }

}
