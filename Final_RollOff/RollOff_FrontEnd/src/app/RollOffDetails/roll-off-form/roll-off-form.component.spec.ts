import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RollOffFormComponent } from './roll-off-form.component';

describe('RollOffFormComponent', () => {
  let component: RollOffFormComponent;
  let fixture: ComponentFixture<RollOffFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RollOffFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RollOffFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
