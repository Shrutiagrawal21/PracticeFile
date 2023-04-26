import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RollOffDetailsComponent } from './roll-off-details.component';

describe('RollOffDetailsComponent', () => {
  let component: RollOffDetailsComponent;
  let fixture: ComponentFixture<RollOffDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RollOffDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RollOffDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
