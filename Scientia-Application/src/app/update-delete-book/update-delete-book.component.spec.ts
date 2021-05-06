import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDeleteBookComponent } from './update-delete-book.component';

describe('UpdateDeleteBookComponent', () => {
  let component: UpdateDeleteBookComponent;
  let fixture: ComponentFixture<UpdateDeleteBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateDeleteBookComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateDeleteBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
