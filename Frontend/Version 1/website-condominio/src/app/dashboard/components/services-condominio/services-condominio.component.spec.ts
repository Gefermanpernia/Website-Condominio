import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicesCondominioComponent } from './services-condominio.component';

describe('ServicesCondominioComponent', () => {
  let component: ServicesCondominioComponent;
  let fixture: ComponentFixture<ServicesCondominioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicesCondominioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicesCondominioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
