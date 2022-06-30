import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllboksComponent } from './allboks.component';

describe('AllboksComponent', () => {
  let component: AllboksComponent;
  let fixture: ComponentFixture<AllboksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllboksComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllboksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
