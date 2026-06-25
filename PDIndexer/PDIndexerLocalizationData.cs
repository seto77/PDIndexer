namespace PDIndexer;

// 260625Cl 自動生成 (tools/i18n_gen_codedata.py 由来)。手で編集しない。
// 多言語化 Phase 2: Localizable=false フォームの Designer 直書き可視ラベルの 11 言語訳テーブル。
// 起動時に Register() を呼ぶと、共有 Crystallography.Localization の中央レジストリへ app-local provider
// として merge される。CodeLocalizer が FullName キー("PDIndexer.<Form>")で引いて実行時に差し替える。
internal static class PDIndexerLocalizationData
{
    /// <summary>フォーム生成前に1回呼ぶこと (Program.Main 冒頭)。</summary>
    public static void Register() => Crystallography.Localization.AddProvider(Populate);

    private static void Populate(System.Collections.Generic.Dictionary<string, Crystallography.Localization.Entry[]> reg)
    {
        reg["PDIndexer.FormAtomicPositionFinder"] = new Crystallography.Localization.Entry[]
        {
            new("dataGridViewCheckBoxColumn1", "HeaderText", "Check", "チェック", "Häkchen", "Cocher", "Marcar", "Marcar", "Spunta", "Отметка", "勾选", "勾選", "선택"),
            new("dataGridViewTextBoxColumn7", "HeaderText", "Intensity", "強度", "Intensität", "Intensité", "Intensidad", "Intensidade", "Intensità", "Интенсивность", "强度", "強度", "강도"),
            new("Delete", "Text", "Delete", "削除", "Löschen", "Supprimer", "Eliminar", "Excluir", "Elimina", "Удалить", "删除", "刪除", "삭제"),
            new("dataGridViewTextBoxColumn8", "HeaderText", "Index", "指数", "Index", "Indice", "Índice", "Índice", "Indice", "Индекс", "指数", "指數", "지수"),
            new("label19", "Text", "Crystal System", "晶系", "Kristallsystem", "Système cristallin", "Sistema cristalino", "Sistema cristalino", "Sistema cristallino", "Кристаллическая система", "晶系", "晶系", "결정계"),
            new("tabPage1", "Text", "Symmetry", "対称性", "Symmetrie", "Symétrie", "Simetría", "Simetria", "Simmetria", "Симметрия", "对称性", "對稱性", "대칭성"),
            new("groupBox4", "Text", "Cell Parameter", "格子定数", "Gitterparameter", "Paramètres de maille", "Parámetros de celda", "Parâmetros de célula", "Parametri di cella", "Параметры ячейки", "晶胞参数", "晶胞參數", "격자 상수"),
            new("tabPage2", "Text", "Chemistry", "化学組成", "Chemie", "Chimie", "Química", "Química", "Chimica", "Химический состав", "化学组成", "化學組成", "화학 조성"),
            new("labelActinoid2", "Text", "Ac: Actinoid", "Ac: アクチノイド", "Ac: Actinoide", "Ac : Actinides", "Ac: Actínidos", "Ac: Actinídeos", "Ac: Attinoidi", "Ac: Актиноиды", "Ac：锕系", "Ac：錒系", "Ac: 악티늄족"),
            new("labelLanthanoid2", "Text", "La: Lanthanoid", "La: ランタノイド", "La: Lanthanoide", "La : Lanthanides", "La: Lantánidos", "La: Lantanídeos", "La: Lantanoidi", "La: Лантаноиды", "La：镧系", "La：鑭系", "La: 란타넘족"),
            new("labelActinoid1", "Text", "Ac", "Ac", "Ac", "Ac", "Ac", "Ac", "Ac", "Ac", "Ac", "Ac", "Ac"),
            new("label3", "Text", "Total atoms in unit cell", "単位格子中の全原子数", "Gesamtatome in Elementarzelle", "Atomes totaux dans la maille", "Átomos totales en la celda unidad", "Átomos totais na célula unitária", "Atomi totali nella cella elementare", "Всего атомов в элементарной ячейке", "晶胞中原子总数", "晶胞中原子總數", "단위 격자 내 전체 원자 수"),
            new("label1", "Text", "Formula", "化学式", "Summenformel", "Formule brute", "Fórmula", "Fórmula", "Formula", "Формула", "化学式", "化學式", "화학식"),
            new("labelLanthanoid1", "Text", "La", "La", "La", "La", "La", "La", "La", "La", "La", "La", "La"),
            new("tabPage3", "Text", "Diffraction Data", "回折データ", "Beugungsdaten", "Données de diffraction", "Datos de difracción", "Dados de difração", "Dati di diffrazione", "Данные дифракции", "衍射数据", "繞射資料", "회절 데이터"),
            new("label15", "Text", "Intensity (rel%)", "強度 (相対%)", "Intensität (rel.%)", "Intensité (rel%)", "Intensidad (rel%)", "Intensidade (rel%)", "Intensità (rel%)", "Интенсивность (отн.%)", "强度 (相对%)", "強度 (相對%)", "강도 (상대%)"),
            new("buttonTest", "Text", "test", "テスト", "Test", "test", "prueba", "teste", "test", "тест", "测试", "測試", "테스트"),
            new("buttonReindexPeaks", "Text", "Reindex peaks", "ピーク再指数付け", "Peaks neu indizieren", "Réindexer les pics", "Reindexar picos", "Reindexar picos", "Reindicizza picchi", "Переиндексировать пики", "重新标定峰", "重新標定峰", "피크 재지수화"),
            new("buttonAddPeak", "Text", "↓ Add Peak ↓", "↓ ピーク追加 ↓", "↓ Peak hinzufügen ↓", "↓ Ajouter un pic ↓", "↓ Añadir pico ↓", "↓ Adicionar pico ↓", "↓ Aggiungi picco ↓", "↓ Добавить пик ↓", "↓ 添加峰 ↓", "↓ 新增峰 ↓", "↓ 피크 추가 ↓"),
            new("groupBox2", "Text", "Combine adjacent peaks", "隣接ピークを結合", "Benachbarte Peaks zusammenführen", "Combiner les pics adjacents", "Combinar picos adyacentes", "Combinar picos adjacentes", "Combina picchi adiacenti", "Объединить соседние пики", "合并相邻峰", "合併相鄰峰", "인접 피크 결합"),
            new("radioButtonAngleThreshold", "Text", "Angle Threshold", "角度しきい値", "Winkelschwelle", "Seuil d'angle", "Umbral de ángulo", "Limiar de ângulo", "Soglia angolo", "Порог по углу", "角度阈值", "角度閾值", "각도 임계값"),
            new("radioButtonEnergyThreshold", "Text", "Energy threshold", "エネルギーしきい値", "Energieschwelle", "Seuil d'énergie", "Umbral de energía", "Limiar de energia", "Soglia energia", "Порог по энергии", "能量阈值", "能量閾值", "에너지 임계값"),
            new("label4", "Text", "eV", "eV", "eV", "eV", "eV", "eV", "eV", "эВ", "eV", "eV", "eV"),
            new("groupBox1", "Text", "Wave source && length", "線源 && 波長", "Strahlungsart && Wellenlänge", "Source && longueur d'onde", "Fuente && longitud de onda", "Fonte && comprimento de onda", "Sorgente && lunghezza d'onda", "Источник && длина волны", "射线源 && 波长", "射線源 && 波長", "선원 && 파장"),
            new("Check", "HeaderText", "Check", "チェック", "Häkchen", "Cocher", "Marcar", "Marcar", "Spunta", "Отметка", "勾选", "勾選", "선택"),
            new("dataGridViewTextBoxColumn5", "HeaderText", "Residual", "残差", "Residuum", "Résidu", "Residuo", "Resíduo", "Residuo", "Невязка", "残差", "殘差", "잔차"),
            new("infoDataGridViewTextBoxColumn", "HeaderText", "Info", "情報", "Info", "Info", "Info", "Info", "Info", "Сведения", "信息", "資訊", "정보"),
            new("fileToolStripMenuItem", "Text", "File", "ファイル", "Datei", "Fichier", "Archivo", "Arquivo", "File", "Файл", "文件", "檔案", "파일"),
            new("readFileToolStripMenuItem", "Text", "Read File", "ファイルを読み込み", "Datei lesen", "Lire le fichier", "Leer archivo", "Ler arquivo", "Leggi file", "Прочитать файл", "读取文件", "讀取檔案", "파일 읽기"),
            new("saveFileToolStripMenuItem", "Text", "Save File", "ファイルを保存", "Datei speichern", "Enregistrer le fichier", "Guardar archivo", "Salvar arquivo", "Salva file", "Сохранить файл", "保存文件", "儲存檔案", "파일 저장"),
            new("toolStripStatusLabelCounter", "Text", "Step: ", "ステップ: ", "Schritt: ", "Étape : ", "Paso: ", "Etapa: ", "Passo: ", "Шаг: ", "步骤: ", "步驟: ", "단계: "),
            new("dataGridViewTextBoxColumn1", "HeaderText", "Crystal", "結晶", "Kristall", "Cristal", "Cristal", "Cristal", "Cristallo", "Кристалл", "晶体", "晶體", "결정"),
            new("label6", "Text", "Hybridization", "混成", "Hybridisierung", "Hybridation", "Hibridación", "Hibridização", "Ibridazione", "Гибридизация", "杂化", "混成", "혼성"),
            new("label7", "Text", "Shaking", "シェイキング", "Rütteln", "Agitation", "Agitación", "Agitação", "Scuotimento", "Встряхивание", "抖动", "抖動", "흔들기"),
            new("label8", "Text", "Randomization", "ランダム化", "Randomisierung", "Randomisation", "Aleatorización", "Aleatorização", "Randomizzazione", "Рандомизация", "随机化", "隨機化", "무작위화"),
            new("dataGridViewTextBoxColumn2", "HeaderText", "Crystal", "結晶", "Kristall", "Cristal", "Cristal", "Cristal", "Cristallo", "Кристалл", "晶体", "晶體", "결정"),
            new("dataGridViewTextBoxColumn3", "HeaderText", "Crystal", "結晶", "Kristall", "Cristal", "Cristal", "Cristal", "Cristallo", "Кристалл", "晶体", "晶體", "결정"),
            new("dataGridViewTextBoxColumn4", "HeaderText", "Crystal", "結晶", "Kristall", "Cristal", "Cristal", "Cristal", "Cristallo", "Кристалл", "晶体", "晶體", "결정"),
            new("groupBox3", "Text", "Ion Radius", "イオン半径", "Ionenradius", "Rayon ionique", "Radio iónico", "Raio iônico", "Raggio ionico", "Ионный радиус", "离子半径", "離子半徑", "이온 반지름"),
            new("label17", "Text", "Hybridization", "混成", "Hybridisierung", "Hybridation", "Hibridación", "Hibridização", "Ibridazione", "Гибридизация", "杂化", "混成", "혼성"),
            new("label20", "Text", "Randomization", "ランダム化", "Randomisierung", "Randomisation", "Aleatorización", "Aleatorização", "Randomizzazione", "Рандомизация", "随机化", "隨機化", "무작위화"),
            new("label22", "Text", "Shaking", "シェイキング", "Rütteln", "Agitation", "Agitación", "Agitação", "Scuotimento", "Встряхивание", "抖动", "抖動", "흔들기"),
            new("groupBox6", "Text", "Balance of algorithm", "アルゴリズムのバランス", "Balance des Algorithmus", "Équilibre de l'algorithme", "Equilibrio del algoritmo", "Equilíbrio do algoritmo", "Bilanciamento dell'algoritmo", "Баланс алгоритма", "算法平衡", "演算法平衡", "알고리즘 균형"),
            new("label31", "Text", "Thread", "スレッド", "Thread", "Thread", "Subproceso", "Thread", "Thread", "Поток", "线程", "執行緒", "스레드"),
        };
        reg["PDIndexer.FormCellFinder"] = new Crystallography.Localization.Entry[]
        {
            new("fileToolStripMenuItem", "Text", "File", "ファイル", "Datei", "Fichier", "Archivo", "Arquivo", "File", "Файл", "文件", "檔案", "파일"),
            new("loadToolStripMenuItem", "Text", "Load", "読み込み", "Laden", "Charger", "Cargar", "Carregar", "Carica", "Загрузить", "加载", "載入", "불러오기"),
            new("label19", "Text", "Crystal System", "晶系", "Kristallsystem", "Système cristallin", "Sistema cristalino", "Sistema cristalino", "Sistema cristallino", "Кристаллическая система", "晶系", "晶系", "결정계"),
            new("groupBox1", "Text", "Restrictions of cell parameters", "格子定数の制約", "Einschränkungen der Gitterkonstanten", "Contraintes des paramètres de maille", "Restricciones de los parámetros de celda", "Restrições dos parâmetros de célula", "Vincoli dei parametri di cella", "Ограничения параметров ячейки", "晶胞参数约束", "晶胞參數限制", "격자 상수 제약"),
            new("useForCalcDataGridViewCheckBoxColumn1", "HeaderText", "Use fo Calc.", "計算に使用", "Für Ber.", "Calcul", "Usar cálc.", "Usar cálc.", "Usa calc.", "Для расч.", "用于计算", "用於計算", "계산 사용"),
            new("reliabilityDataGridViewTextBoxColumn", "HeaderText", "Reliability", "信頼度", "Zuverlässigkeit", "Fiabilité", "Fiabilidad", "Confiabilidade", "Affidabilità", "Надёжность", "可靠度", "可靠度", "신뢰도"),
            new("dObsDataGridViewTextBoxColumn3", "HeaderText", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs", "d_obs"),
            new("dCalcDataGridViewTextBoxColumn1", "HeaderText", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc", "d_calc"),
            new("diff", "HeaderText", "diff", "差", "Diff.", "diff.", "dif.", "dif.", "diff.", "разн.", "差值", "差值", "차이"),
            new("Intensity", "HeaderText", "Int.", "強度", "Int.", "Int.", "Int.", "Int.", "Int.", "Инт.", "强度", "強度", "강도"),
            new("Delete", "Text", "Delete", "削除", "Löschen", "Supprimer", "Eliminar", "Excluir", "Elimina", "Удалить", "删除", "刪除", "삭제"),
            new("groupBox2", "Text", "Peak Information", "ピーク情報", "Peak-Informationen", "Informations sur les pics", "Información de picos", "Informação de picos", "Informazioni sui picchi", "Информация о пиках", "峰信息", "峰資訊", "피크 정보"),
            new("label8", "Text", "Reliability", "信頼度", "Zuverlässigkeit", "Fiabilité", "Fiabilidad", "Confiabilidade", "Affidabilità", "Надёжность", "可靠度", "可靠度", "신뢰도"),
            new("buttonAddPeak", "Text", "↓ Add Peak ↓", "↓ ピーク追加 ↓", "↓ Peak hinzufügen ↓", "↓ Ajouter un pic ↓", "↓ Añadir pico ↓", "↓ Adicionar pico ↓", "↓ Aggiungi picco ↓", "↓ Добавить пик ↓", "↓ 添加峰 ↓", "↓ 新增峰 ↓", "↓ 피크 추가 ↓"),
            new("volumeDataGridViewTextBoxColumn1", "HeaderText", "Volume", "体積", "Volumen", "Volume", "Volumen", "Volume", "Volume", "Объём", "体积", "體積", "부피"),
            new("σDQDataGridViewTextBoxColumn", "HeaderText", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ", "ΣdQ"),
            new("alphaDataGridViewTextBoxColumn", "HeaderText", "alpha", "alpha", "alpha", "alpha", "alpha", "alpha", "alpha", "alpha", "alpha", "alpha", "alpha"),
            new("betaDataGridViewTextBoxColumn", "HeaderText", "beta", "beta", "beta", "beta", "beta", "beta", "beta", "beta", "beta", "beta", "beta"),
            new("gammaDataGridViewTextBoxColumn", "HeaderText", "gamma", "gamma", "gamma", "gamma", "gamma", "gamma", "gamma", "gamma", "gamma", "gamma", "gamma"),
            new("volumeDataGridViewTextBoxColumn", "HeaderText", "Volume", "体積", "Volumen", "Volume", "Volumen", "Volume", "Volume", "Объём", "体积", "體積", "부피"),
            new("label9", "Text", "Candidates (best 300)", "候補 (上位 300)", "Kandidaten (beste 300)", "Candidats (300 meilleurs)", "Candidatos (mejores 300)", "Candidatos (300 melhores)", "Candidati (migliori 300)", "Кандидаты (лучшие 300)", "候选 (最佳 300)", "候選 (最佳 300)", "후보 (상위 300)"),
            new("toolStripStatusLabelTryNumber", "Text", "Try Number: ", "試行回数: ", "Versuchsnummer: ", "Numéro d'essai : ", "Número de intento: ", "Número de tentativa: ", "Numero tentativo: ", "Номер попытки: ", "尝试次数: ", "嘗試次數: ", "시도 횟수: "),
            new("button1", "Text", "Resume!", "再開!", "Fortsetzen!", "Reprendre !", "¡Reanudar!", "Retomar!", "Riprendi!", "Возобновить!", "继续!", "繼續!", "재개!"),
            new("dObsDataGridViewTextBoxColumn", "HeaderText", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs"),
            new("reliabilityDataGridViewTextBoxColumn1", "HeaderText", "Reliability", "信頼度", "Zuverlässigkeit", "Fiabilité", "Fiabilidad", "Confiabilidade", "Affidabilità", "Надёжность", "可靠度", "可靠度", "신뢰도"),
            new("useForCalcDataGridViewCheckBoxColumn", "HeaderText", "Use for Calc.", "計算に使用", "Für Ber.", "Calcul", "Usar cálc.", "Usar cálc.", "Usa calc.", "Для расч.", "用于计算", "用於計算", "계산 사용"),
            new("dCalcDataGridViewTextBoxColumn", "HeaderText", "d calc", "d calc", "d calc", "d calc", "d calc", "d calc", "d calc", "d calc", "d calc", "d calc", "d calc"),
            new("dObsDataGridViewTextBoxColumn1", "HeaderText", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs"),
            new("dObsDataGridViewTextBoxColumn2", "HeaderText", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs", "d obs"),
            new("Reliability", "HeaderText", "Reliability", "信頼度", "Zuverlässigkeit", "Fiabilité", "Fiabilidad", "Confiabilidade", "Affidabilità", "Надёжность", "可靠度", "可靠度", "신뢰도"),
            new("ColumnDelete", "Text", "delete", "削除", "löschen", "supprimer", "eliminar", "excluir", "elimina", "удалить", "删除", "刪除", "삭제"),
            new("groupBox3", "Text", "Wave Source", "線源", "Strahlungsart", "Source de rayonnement", "Fuente de radiación", "Fonte de radiação", "Sorgente di radiazione", "Источник излучения", "波源", "波源", "선원"),
            new("label10", "Text", "Y-Axis", "Y軸", "Y-Achse", "Axe Y", "Eje Y", "Eixo Y", "Asse Y", "Ось Y", "Y轴", "Y軸", "Y축"),
            new("label11", "Text", "X-Axis", "X軸", "X-Achse", "Axe X", "Eje X", "Eixo X", "Asse X", "Ось X", "X轴", "X軸", "X축"),
            new("buttonSendToAtomicPositionFinder", "Text", "Send the selected cell constant to \\\"Atomic Position Finder\\\"", "選択した格子定数を「Atomic Position Finder」に送信", "Ausgewählte Gitterkonstante an \\\"Atomic Position Finder\\\" senden", "Envoyer le paramètre de maille sélectionné vers \\\"Atomic Position Finder\\\"", "Enviar el parámetro de celda seleccionado a \\\"Atomic Position Finder\\\"", "Enviar o parâmetro de célula selecionado para \\\"Atomic Position Finder\\\"", "Invia il parametro di cella selezionato a \\\"Atomic Position Finder\\\"", "Отправить выбранный параметр ячейки в \\\"Atomic Position Finder\\\"", "将选定的晶胞参数发送到 \\\"Atomic Position Finder\\\"", "將選定的晶胞參數傳送到 \\\"Atomic Position Finder\\\"", "선택한 격자 상수를 \\\"Atomic Position Finder\\\"로 보내기"),
        };
        reg["PDIndexer.FormExportGSAS"] = new Crystallography.Localization.Entry[]
        {
            new("checkBox1", "Text", "Overwrite below information, if crystal phase already exists", "結晶相が既に存在する場合、以下の情報で上書きする", "Untenstehende Informationen überschreiben, falls Kristallphase bereits vorhanden", "Écraser les informations ci-dessous si la phase cristalline existe déjà", "Sobrescribir la información siguiente si la fase cristalina ya existe", "Sobrescrever as informações abaixo se a fase cristalina já existir", "Sovrascrivi le informazioni sottostanti se la fase cristallina esiste già", "Перезаписать приведённую ниже информацию, если кристаллическая фаза уже существует", "若晶相已存在，则用以下信息覆盖", "若晶相已存在，則用下列資訊覆寫", "결정상이 이미 존재하면 아래 정보로 덮어쓰기"),
            new("checkBox2", "Text", "Use template file", "テンプレートファイルを使用", "Vorlagendatei verwenden", "Utiliser un fichier modèle", "Usar archivo de plantilla", "Usar arquivo de modelo", "Usa file modello", "Использовать файл шаблона", "使用模板文件", "使用範本檔案", "템플릿 파일 사용"),
            new("checkBox3", "Text", "Cell constants", "格子定数", "Gitterkonstanten", "Paramètres de maille", "Parámetros de celda", "Parâmetros de célula", "Parametri di cella", "Параметры ячейки", "晶胞参数", "晶胞參數", "격자 상수"),
            new("checkBox4", "Text", "Coordinates", "原子座標", "Koordinaten", "Coordonnées", "Coordenadas", "Coordenadas", "Coordinate", "Координаты", "坐标", "座標", "좌표"),
            new("checkBox5", "Text", "Occupancies", "占有率", "Besetzungen", "Occupations", "Ocupaciones", "Ocupações", "Occupazioni", "Заселённости", "占有率", "佔有率", "점유율"),
            new("checkBox6", "Text", "Displacement parameters (U)", "変位パラメータ (U)", "Auslenkungsparameter (U)", "Paramètres de déplacement (U)", "Parámetros de desplazamiento (U)", "Parâmetros de deslocamento (U)", "Parametri di spostamento (U)", "Параметры смещения (U)", "位移参数 (U)", "位移參數 (U)", "변위 매개변수 (U)"),
            new("label2", "Text", "EXP file contents", "EXP ファイルの内容", "Inhalt der EXP-Datei", "Contenu du fichier EXP", "Contenido del archivo EXP", "Conteúdo do arquivo EXP", "Contenuto del file EXP", "Содержимое файла EXP", "EXP 文件内容", "EXP 檔案內容", "EXP 파일 내용"),
            new("buttonOpen", "Text", "Open", "開く", "Öffnen", "Ouvrir", "Abrir", "Abrir", "Apri", "Открыть", "打开", "開啟", "열기"),
            new("buttonOK", "Text", "OK", "OK", "OK", "OK", "Aceptar", "OK", "OK", "OK", "确定", "確定", "확인"),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "Annuler", "Cancelar", "Cancelar", "Annulla", "Отмена", "取消", "取消", "취소"),
            new("checkBox7", "Text", "Create Exp file", "Exp ファイルを作成", "Exp-Datei erstellen", "Créer un fichier Exp", "Crear archivo Exp", "Criar arquivo Exp", "Crea file Exp", "Создать файл Exp", "创建 Exp 文件", "建立 Exp 檔案", "Exp 파일 생성"),
            new("label1", "Text", "GSA file contents", "GSA ファイルの内容", "Inhalt der GSA-Datei", "Contenu du fichier GSA", "Contenido del archivo GSA", "Conteúdo do arquivo GSA", "Contenuto del file GSA", "Содержимое файла GSA", "GSA 文件内容", "GSA 檔案內容", "GSA 파일 내용"),
            new("this", "Text", "Export GSAS file -option-", "GSAS ファイルのエクスポート -オプション-", "GSAS-Datei exportieren -Optionen-", "Exporter le fichier GSAS -option-", "Exportar archivo GSAS -opción-", "Exportar arquivo GSAS -opção-", "Esporta file GSAS -opzione-", "Экспорт файла GSAS -параметры-", "导出 GSAS 文件 -选项-", "匯出 GSAS 檔案 -選項-", "GSAS 파일 내보내기 -옵션-"),
        };
        reg["PDIndexer.FormLPO"] = new Crystallography.Localization.Entry[]
        {
            new("buttonGetPeakIntensities", "Text", "Get  peak intensities", "ピーク強度を取得", "Peak-Intensitäten abrufen", "Obtenir les intensités des pics", "Obtener intensidades de picos", "Obter intensidades dos picos", "Ottieni intensità dei picchi", "Получить интенсивности пиков", "获取峰强度", "取得峰強度", "피크 강도 가져오기"),
            new("buttonAnalyze", "Text", "Analyze LPO", "LPO を解析", "LPO analysieren", "Analyser la LPO", "Analizar LPO", "Analisar LPO", "Analizza LPO", "Анализ LPO", "分析 LPO", "分析 LPO", "LPO 분석"),
            new("label4", "Text", "Resolution", "分解能", "Auflösung", "Résolution", "Resolución", "Resolução", "Risoluzione", "Разрешение", "分辨率", "解析度", "분해능"),
            new("label6", "Text", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM", "HWHM"),
        };
        reg["PDIndexer.FormLimitChanger"] = new Crystallography.Localization.Entry[]
        {
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "Annuler", "Cancelar", "Cancelar", "Annulla", "Отмена", "取消", "取消", "취소"),
            new("buttonOK", "Text", "OK", "OK", "OK", "OK", "Aceptar", "OK", "OK", "OK", "确定", "確定", "확인"),
            new("label1", "Text", "Maximum X", "X 最大値", "Maximum X", "X maximum", "X máximo", "X máximo", "X massimo", "Максимум X", "X 最大值", "X 最大值", "X 최댓값"),
            new("label2", "Text", "Minimum X", "X 最小値", "Minimum X", "X minimum", "X mínimo", "X mínimo", "X minimo", "Минимум X", "X 最小值", "X 最小值", "X 최솟값"),
            new("label3", "Text", "Maximum Y", "Y 最大値", "Maximum Y", "Y maximum", "Y máximo", "Y máximo", "Y massimo", "Максимум Y", "Y 最大值", "Y 最大值", "Y 최댓값"),
            new("label4", "Text", "Minimum Y", "Y 最小値", "Minimum Y", "Y minimum", "Y mínimo", "Y mínimo", "Y minimo", "Минимум Y", "Y 最小值", "Y 最小值", "Y 최솟값"),
        };
        reg["PDIndexer.FormPrintOption"] = new Crystallography.Localization.Entry[]
        {
            new("button1", "Text", "OK", "OK", "OK", "OK", "Aceptar", "OK", "OK", "OK", "确定", "確定", "확인"),
            new("button2", "Text", "Cancel", "キャンセル", "Abbrechen", "Annuler", "Cancelar", "Cancelar", "Annulla", "Отмена", "取消", "取消", "취소"),
            new("checkBoxPrintProfileName", "Text", "Print Profile Name", "プロファイル名を印刷", "Profilnamen drucken", "Imprimer le nom du profil", "Imprimir nombre del perfil", "Imprimir nome do perfil", "Stampa nome del profilo", "Печать имени профиля", "打印图谱名称", "列印圖譜名稱", "프로파일 이름 인쇄"),
            new("radioButtonUpperLeft", "Text", "Upper Left", "左上", "Oben links", "En haut à gauche", "Superior izquierda", "Superior esquerdo", "In alto a sinistra", "Слева вверху", "左上", "左上", "왼쪽 위"),
            new("radioButtonUpperRight", "Text", "Upper Right", "右上", "Oben rechts", "En haut à droite", "Superior derecha", "Superior direito", "In alto a destra", "Справа вверху", "右上", "右上", "오른쪽 위"),
            new("radioButtonLowerLeft", "Text", "Lower Left", "左下", "Unten links", "En bas à gauche", "Inferior izquierda", "Inferior esquerdo", "In basso a sinistra", "Слева внизу", "左下", "左下", "왼쪽 아래"),
            new("radioButtonLowerRight", "Text", "Lower Right", "右下", "Unten rechts", "En bas à droite", "Inferior derecha", "Inferior direito", "In basso a destra", "Справа внизу", "右下", "右下", "오른쪽 아래"),
            new("checkBoxPrintProfile", "Text", "Print Profile", "プロファイルを印刷", "Profil drucken", "Imprimer le profil", "Imprimir perfil", "Imprimir perfil", "Stampa profilo", "Печать профиля", "打印图谱", "列印圖譜", "프로파일 인쇄"),
            new("checkBoxPrintDiffractionPeak", "Text", "Print Diffraction Peak", "回折ピークを印刷", "Beugungspeak drucken", "Imprimer le pic de diffraction", "Imprimir pico de difracción", "Imprimir pico de difração", "Stampa picco di diffrazione", "Печать дифракционного пика", "打印衍射峰", "列印繞射峰", "회절 피크 인쇄"),
            new("this", "Text", "Print Option", "印刷オプション", "Druckoptionen", "Options d'impression", "Opciones de impresión", "Opções de impressão", "Opzioni di stampa", "Параметры печати", "打印选项", "列印選項", "인쇄 옵션"),
        };
        reg["PDIndexer.FormTwoThetaCalibration"] = new Crystallography.Localization.Entry[]
        {
            new("buttonRevert", "Text", "Revert", "元に戻す", "Zurücksetzen", "Rétablir", "Revertir", "Reverter", "Ripristina", "Вернуть", "还原", "還原", "되돌리기"),
            new("label2", "Text", "Order", "次数", "Ordnung", "Ordre", "Orden", "Ordem", "Ordine", "Порядок", "阶数", "階數", "차수"),
            new("this", "Text", "2θ Calibration", "2θ 較正", "2θ-Kalibrierung", "Étalonnage 2θ", "Calibración 2θ", "Calibração 2θ", "Calibrazione 2θ", "Калибровка 2θ", "2θ 校准", "2θ 校正", "2θ 보정"),
        };
    }
}
