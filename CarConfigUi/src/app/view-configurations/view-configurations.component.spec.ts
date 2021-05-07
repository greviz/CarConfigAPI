import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewConfigurationsComponent } from './view-configurations.component';

describe('ViewConfigurationsComponent', () => {
  let component: ViewConfigurationsComponent;
  let fixture: ComponentFixture<ViewConfigurationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewConfigurationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewConfigurationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
