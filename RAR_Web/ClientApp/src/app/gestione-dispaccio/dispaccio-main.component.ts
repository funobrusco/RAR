import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-dispaccio-main',
  templateUrl: './dispaccio-main.component.html',
  styleUrls: ['./dispaccio-main.component.css']
})

export class DispaccioMainComponent {

  countryForm: FormGroup;
  countries = ['USA', 'Canada', 'Uk']

  public dispacci: Dispaccio[];
  public dispaccioSearch: DispaccioSearch;
  servizi = ['Postel'];
  dispaccioForm: FormGroup;
  //dispaccioForm = new FormGroup({
  //  //servizioSelect: new FormControl(''),
  //  //dataLavorazione: new FormControl(''),
  //  //codeRacc: new FormControl(''),
  //});


  //onSubmit() {
  //  this.dispaccioSearch = new DispaccioSearch();
  //  this.dispaccioSearch.dataLavorazione = this.dispaccioForm.controls['dataLavorazione'].value;
  //  this.dispaccioSearch.codeRacc = this.dispaccioForm.controls['dataLavorazione'].value;
  //  this.dispaccioSearch.servizio = this.dispaccioForm.controls['dataLavorazione'].value;
  //  console.warn(this.dispaccioForm.value);
  //}

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private fb: FormBuilder) {

    
    //let params = new HttpParams().set('userArrivo', 'deang241');
    //http.get<Dispaccio[]>(baseUrl + 'Dispacci/', { params: params }).subscribe(result => {

    http.get<Dispaccio[]>(baseUrl + 'Dispacci/' + encodeURIComponent('rete.testposte\\deang241')).subscribe(result => {
      this.dispacci = result;
    }, error => console.error(error));
  }


  ngOnInit() {
    this.dispaccioForm = this.fb.group({
      servizioSelect: ['Postel']
    });
  }

  ngAfterViewInit() {
    //this.dispaccioForm.controls['dataLavorazione'].setValue(new Date());
  }
}

interface Dispaccio {
  id: number;
  codeRacc: string;
  dataArrivo: string;
  dataApertura: string;
  dataChiusura: string;
  mittente: string;
  usrArrivo: string;
  usrApertura: string;
  usrChiusura: string;
}

class DispaccioSearch {
  servizio: number;
  dataLavorazione: Date;
  codeRacc: string;
}
