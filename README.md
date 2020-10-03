# MenuInfoForUnity
Unityでデータのセーブ・ロードとか、インベントリとかの画面をUIとして表示

# 制作バージョン
Unity 2019.4.1f1

# WebGLのサンプル
https://unityroom.com/games/mugitea-menuinfopackage

# サンプル動画
https://twitter.com/tea59595959/status/1312463506248089601

# 導入方法
.unitypackageをAssetsフォルダに投げるだけ

# できること
- ゼ〇ダの伝説BoW的な, メニュー画面を左右に遷移できるようになる. 遷移速度・イージングはAnimationCurveによりカスタマイズ可能(Sample1).
- セーブ・ロードができるようになる(ただし, PlayerPlefs使用の為, 機密性は保証できない). 複数のセーブデータに対応したもの・簡易的なものの2種類(Sample2, Sample4).
- アイテム欄が表示できるようになる. もちろんアイテムのカスタマイズも可能(Sample3, Sample4). ItemのデータはScriptableObjectで作成しているので, Project内で右クリック > Create > MenuInfoPackage > ItemData で作成できます.
- 取得アイテムの3Dモデルをマウスでグリグリ動かせるようになる(Sample3, Sample4).

# 注意点
- サンプル4ではセーブ・ロードを同画面に置いているが, これだとセーブ後にロード候補一覧の初期化ができていない(シーン遷移などで回避可能). セーブ画面とロード画面は分ける必要がある (簡易版は不要).

# サンプル
ManuInfoPackage > Scenes フォルダ内に各種サンプルがあります.

- Sample1
  - ← → キー or ボタンでターゲットに移動するサンプル.
- Sample2
  - Save & Loadのサンプル.WebGLでの動作も確認.
- Sample3
  - アイテム欄の表示サンプル.
- Sample4
  - 取得アイテムの3Dモデル表示・ドラッグでの回転, 複数のセーブデータに対応したもののサンプル.

# 各クラスの説明
- DataManageButton
  - Save・Loadボタン用のクラス. 簡易的なセーブで, セーブデータ1つのみしか対応できない.
- Datas
  - Playerの各種データ. Saveをするとこのクラスのデータが保存される.
- DisplayItemElement
  - Itemを表示する要素用のクラス.
- DisplayItemList
  - Itemを一覧表示する. 所持数も表示可能. DisplayItemElementの親.
- ItemData
  - Itemデータ.
- ItemDescription
  - Itemの説明用UIにアタッチするクラス.
- ItemModelRotationPanel
  - Itemの3Dモデルをドラッグして回転させる用のPanelにアタッチするクラス.
- MenuParentManager
  - メニュー画面全体の親クラス. メニュー画面の移動を制御する.
- MultipleSaveDataManager
  - 複数のセーブデータに対応したクラス. ボタンにアタッチする.
- Player
  - 移動したり.
- PositionText
  - Playerの現在位置を表示するだけ.テスト用.
- SaveData
  - Save・Loadの中身.

# 使用素材
PixelFont
http://itouhiro.hatenablog.com/entry/20130602/font