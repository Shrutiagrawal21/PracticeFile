import { TestBed } from '@angular/core/testing';

import { RollOffService } from './roll-off.service';

describe('RollOffService', () => {
  let service: RollOffService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RollOffService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
