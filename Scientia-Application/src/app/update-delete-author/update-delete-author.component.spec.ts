import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDeleteAuthorComponent } from './update-delete-author.component';

describe('UpdateDeleteAuthorComponent', () => {
  let component: UpdateDeleteAuthorComponent;
  let fixture: ComponentFixture<UpdateDeleteAuthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateDeleteAuthorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateDeleteAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
