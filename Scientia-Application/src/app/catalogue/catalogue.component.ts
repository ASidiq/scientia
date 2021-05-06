import { Component, OnInit, ElementRef, HostListener, AfterViewInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { MdbTableDirective, MdbTablePaginationComponent } from 'angular-bootstrap-md';
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
  headElements = ['id', 'cover', 'title', 'author', 'date', 'type', 'genre', 'rating', 'pages', 'copies'];

  searchText: string = '';
  previous: string;

  maxVisibleItems: number = 15;


  constructor(private cdRef: ChangeDetectorRef, private service: SharedService) { }

  @HostListener('input') oninput() {
    this.mdbTablePagination.searchText = this.searchText;
  }


  //Populating array which will be used as datasource
  ngOnInit(): void {
    this.refreshCatalogueList();
  }

  refreshCatalogueList() {
    this.service.getEntireCatalogue().subscribe(data => {
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
          location: el.Location,
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
