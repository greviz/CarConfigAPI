import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreviewConfigurationComponent } from './preview-configuration.component';

describe('PreviewConfigurationComponent', () => {
  let component: PreviewConfigurationComponent;
  let fixture: ComponentFixture<PreviewConfigurationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreviewConfigurationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreviewConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
