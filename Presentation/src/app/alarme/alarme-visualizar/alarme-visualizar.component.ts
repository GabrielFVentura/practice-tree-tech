import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {TreeTechService} from '../../services/treetech-service';
import {AlarmeDTO} from '../../models/alarme/alarme';
import {faArrowCircleLeft} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-alarme-visualizar',
  templateUrl: './alarme-visualizar.component.html',
  styleUrls: ['./alarme-visualizar.component.css']
})
export class AlarmeVisualizarComponent implements OnInit {
  public alarme: AlarmeDTO;
  faArrowCircleLeft = faArrowCircleLeft;
  public numeroSerieFormatado: string;

  constructor(
    private _route: ActivatedRoute,
    public treeTechService: TreeTechService,
    private _router: Router
) { }

  ngOnInit(): void {
    this.verificarFluxo();
    setTimeout(() => {
      document.getElementById('svgID');
    }, 1000);
  }

  verificarFluxo(): void {
    this._route.queryParams.subscribe((params) => {
      if (params.id !== undefined) {
        const id = params.id;
        this.treeTechService.BuscarAlarmePorId(id).subscribe(data => {
          console.log(data);
          this.alarme = data;
          this.numeroSerieFormatado = this.alarme.equipamentoDTO.numeroSerie;
          this.numeroSerieFormatado = `${this.numeroSerieFormatado.substring(0, 5)}-${this.numeroSerieFormatado.substring(5, 8)}-${this.numeroSerieFormatado[8]}-${this.numeroSerieFormatado.substring(9, 13)}/${this.numeroSerieFormatado.substring(13, 17)}`;
          this.adicionarSVG();
        });
      }
    });
  }

  adicionarSVG(): void {
    const svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
    svg.id = 'svgID';
    svg.setAttribute('width', '800');
    svg.setAttribute('height', '600');
    svg.innerHTML = this.constuirSVG();
    document.getElementById('card-body-id').appendChild(svg);
  }

  constuirSVG(): string {
    return `
    <g id="Layer_1">
      <title>Layer 1</title>
    <rect fill="#000000" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="-5.63154" y="0.37722" width="533.68418" height="522.10527" id="svg_92" stroke="#000"/>
    <rect fill="#ffffff" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="0.15789" y="-0.67541" width="521.05263" height="521.05263" id="svg_3"/>
    <rect fill="#8e8e8e" stroke-width="0" stroke-opacity="null" opacity="undefined" x="0.15789" y="-0.67542" width="171.57894" height="521.05264" id="svg_4" stroke="#000"/>
    <rect fill="#727272" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="39.10526" y="-1.72802" width="131.57894" height="523.15787" id="svg_5" stroke="#000"/>
    <rect fill="#b7b7b7" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="170.68421" y="-0.67541" width="352.63158" height="522.10526" id="svg_6" stroke="#000"/>
    <rect fill="#727272" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="39.10526" y="-1.72802" width="131.57894" height="523.15787" id="svg_7" stroke="#000"/>
    <image x="135.84208" y="-8.04384" width="141.05262" height="105.78947" id="svg_8" xlink:href="data:image/webp;base64,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"/>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="473.3158" cy="471.42985" id="svg_9" rx="47.89474" ry="47.89474"/>
    <ellipse fill="${this.alarme.ativo ? '#FF0000' : '#000000'}" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="473.3158" cy="471.42985" id="svg_92" rx="30.89474" ry="30.89474"/>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="368.05264" cy="473.53511" id="svg_11" rx="47.89474" ry="47.89474"/>
    <rect fill="#bf7676" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="185.42105" y="100.37722" width="320" height="67.36842" id="svg_12" stroke="#000"/>
    <text fill="#000000" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" fill-opacity="null" opacity="undefined" x="245.28622" y="34.80307" id="svg_15" font-size="28" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve" font-weight="normal" font-style="normal">${this.alarme.equipamentoDTO.nomeEquipamento}</text>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="447.12959" y="103.53512" width="50.52632" height="62.10526" id="svg_17" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="384.52228" y="103.53512" width="50.52632" height="62.10526" id="svg_19" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="320.44495" y="103.53512" width="50.52632" height="62.10526" id="svg_20" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="194.35927" y="103.53512" width="50.52632" height="62.10526" id="svg_21" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="257.40312" y="103.53512" width="50.52632" height="62.10526" id="svg_22" stroke="#000"/>
    <rect fill="#bf7676" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="185.42105" y="257.40356" width="320" height="67.36842" id="svg_29" stroke="#000"/>
    <rect fill="#bf7676" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="185.42105" y="177.34126" width="320" height="67.36842" id="svg_30" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="447.12959" y="181.49384" width="50.52632" height="62.10526" id="svg_31" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="384.52228" y="181.49384" width="50.52632" height="62.10526" id="svg_32" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="320.44495" y="181.49384" width="50.52632" height="62.10526" id="svg_33" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="194.35927" y="181.49384" width="50.52632" height="62.10526" id="svg_34" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="257.40312" y="181.49384" width="50.52632" height="62.10526" id="svg_35" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="447.12959" y="259.61237" width="50.52632" height="62.10526" id="svg_36" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="384.52228" y="259.61237" width="50.52632" height="62.10526" id="svg_37" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="320.44495" y="259.61237" width="50.52632" height="62.10526" id="svg_38" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="194.35927" y="259.61237" width="50.52632" height="62.10526" id="svg_39" stroke="#000"/>
    <rect fill="#7c0c2c" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="257.40312" y="259.61237" width="50.52632" height="62.10526" id="svg_40" stroke="#000"/>
    <text fill="#ff0f1f" stroke="#000" stroke-width="null" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" x="460.68421" y="128.79827" id="svg_41" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve"/>
    <text fill="#ea8194" opacity="undefined" x="197.52632" y="160.37722" id="svg_45" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="265.10002" y="160.37722" id="svg_47" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="326.23426" y="160.37722" id="svg_48" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="390.43392" y="160.37722" id="svg_49" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="451.52282" y="160.37722" id="svg_50" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="197.52632" y="238.44956" id="svg_51" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="265.10002" y="238.44956" id="svg_52" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="326.23426" y="238.44956" id="svg_53" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="390.43392" y="238.44956" id="svg_54" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="451.52282" y="238.44956" id="svg_55" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="197.52632" y="317.64615" id="svg_56" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="265.10002" y="317.64615" id="svg_57" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="326.23426" y="317.64615" id="svg_58" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="390.43392" y="317.64615" id="svg_59" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <text fill="#ea8194" opacity="undefined" x="451.52282" y="317.64615" id="svg_60" font-size="75" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.gN()}</text>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="259.97588" cy="473.53511" id="svg_61" rx="47.89474" ry="47.89474"/>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" fill-opacity="null" opacity="undefined" cx="19.10527" cy="34.06143" id="svg_63" rx="16.31579" ry="15.78947"/>
    <ellipse fill="#7f0000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="33.53511" id="svg_65" rx="12.10526" ry="13.15789" stroke="#000"/>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" fill-opacity="null" opacity="undefined" cx="19.10527" cy="94.14447" id="svg_67" rx="16.31579" ry="15.78947"/>
    <ellipse fill="${this.gB() ? '#FF0000' : '#000000'}" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="93.61816" id="svg_68" rx="12.10526" ry="13.15789" stroke="#000"/>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" fill-opacity="null" opacity="undefined" cx="19.10527" cy="146.04184" id="svg_69" rx="16.31579" ry="15.78947"/>
    <ellipse fill="${this.gB() ? '#FF0000' : '#000000'}" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="145.51552" id="svg_70" rx="12.10526" ry="13.15789" stroke="#000"/>
    <ellipse fill="#8e8e8e" stroke="#000" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" fill-opacity="null" opacity="undefined" cx="19.10527" cy="195.45768" id="svg_71" rx="16.31579" ry="15.78947"/>
    <ellipse fill="${this.gB() ? '#FF0000' : '#000000'}" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="194.93137" id="svg_72" rx="12.10526" ry="13.15789" stroke="#000"/>
    <ellipse fill="${this.gB() ? '#FF0000' : '#000000'}" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="244.12721" id="svg_74" rx="12.10526" ry="13.15789" stroke="#000"/>
    <ellipse fill="${this.gB() ? '#FF0000' : '#000000'}" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="33.53511" id="svg_76" rx="12.10526" ry="13.15789" stroke="#000"/>
    <ellipse fill="${this.gB() ? '#FF0000' : '#000000'}" stroke-width="0" stroke-dasharray="null" stroke-opacity="null" opacity="undefined" cx="19.10526" cy="287.0426" id="svg_77" rx="12.10526" ry="13.15789" stroke="#000"/>
    <text fill="#000000" opacity="undefined" x="230.8421" y="377.21932" id="svg_85" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">${this.numeroSerieFormatado}</text>
    <text fill="#000000" opacity="undefined" x="48" y="38.27195" id="svg_86" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">Sensor 1</text>
    <text fill="#000000" opacity="undefined" x="48" y="101.85822" id="svg_87" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">Sensor 2</text>
    <text fill="#000000" opacity="undefined" x="48" y="150.9478" id="svg_88" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">Parametro 1</text>
    <text fill="#000000" opacity="undefined" x="48" y="202.96759" id="svg_89" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">Sensor 3</text>
    <text fill="#000000" opacity="undefined" x="48" y="254.49488" id="svg_90" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">Parametro 2</text>
    <text fill="#000000" opacity="undefined" x="48" y="296.34065" id="svg_91" font-size="24" font-family="'Montserrat Thin'" text-anchor="start" xml:space="preserve">Sensor 4</text>

    </g>`;
  }

  gN = (): number => Math.floor(Math.random() * 10);
  gB = (): boolean => {
    const k = Math.floor(Math.random() * 2);
    return k > 0;
  }

  voltar(): void {
    this._router.navigate(['alarme/lista']);
  }
}
