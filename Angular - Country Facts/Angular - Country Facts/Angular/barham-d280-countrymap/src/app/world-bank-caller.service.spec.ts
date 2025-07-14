import { TestBed } from '@angular/core/testing';

import { WorldBankCallerService } from './world-bank-caller.service';

describe('WorldBankCallerService', () => {
  let service: WorldBankCallerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorldBankCallerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
