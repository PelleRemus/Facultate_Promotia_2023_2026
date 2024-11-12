import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCvComponent } from './edit-cv.component';

describe('EditCvComponent', () => {
  let component: EditCvComponent;
  let fixture: ComponentFixture<EditCvComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditCvComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditCvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
