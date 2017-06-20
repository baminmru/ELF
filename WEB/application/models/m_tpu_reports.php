
<?php
class  M_tpu_reports extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tpu_reportsid) as tpu_reportsid, B2G(tpu_reportsid) as id,B2G(instanceid) as instanceid, TPU_REPORTS_BRIEF_F(tpu_reportsid , NULL) as  brief,thefile,thefile_ext,B2G(ReportType) reporttype, TPD_REPORT_BRIEF_F(reporttype, NULL) as reporttype_grid', 'PartName' => 'tpu_reports', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
//////////////////////////// support file data for: thefile
    if ($_FILES['thefile_fu']['size'] > 0 ) {
       $ext = pathinfo($_FILES['thefile_fu']['name'], PATHINFO_EXTENSION);
       $orig = pathinfo($_FILES['thefile_fu']['name'], PATHINFO_BASENAME) ;
       $filename = strtolower(trim($this->jservice->get(array('Action' => 'NewGuid')),'{}') . '.' . $ext);
       if (move_uploaded_file($_FILES['thefile_fu']['tmp_name'], $this->jservice->temp_file_path().$filename)) {
          $file_data = file_get_contents($this->jservice->temp_file_path().$filename);
          $this->jservice->get(array('Action' => 'AddFile', 'FileName'=>$filename, 'Data'=>utf8_encode($file_data), 'FileID'=>'iu_files',
            'OrigName'=>$orig   ));
          unlink($this->jservice->temp_file_path().$filename);
       }
	   if (!empty($data)) {
	        $data['thefile']=$filename;
	        $data['thefile_ext']=$ext;
       }
    }
//////////////////////////// end support file data for: thefile
	if (!empty($data)) {
	    if (empty($data['tpu_reportsid'])) {
	        $data['tpu_reportsid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpu_reports', 'RowID' => $data['tpu_reportsid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tpu_reports', 'RowID' => $data['tpu_reportsid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tpu_reportsid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tpu_reports', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_reportsid) as tpu_reportsid, B2G(tpu_reportsid) as id,B2G(instanceid) as instanceid, TPU_REPORTS_BRIEF_F(tpu_reportsid , NULL) as  brief,thefile,thefile_ext,B2G(ReportType) reporttype, TPD_REPORT_BRIEF_F(reporttype, NULL) as reporttype_grid', 'ViewName' => 'tpu_reports'));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_reportsid) as tpu_reportsid, B2G(tpu_reportsid) as id,B2G(instanceid) as instanceid, TPU_REPORTS_BRIEF_F(tpu_reportsid , NULL) as  brief,thefile,thefile_ext,B2G(ReportType) reporttype, TPD_REPORT_BRIEF_F(reporttype, NULL) as reporttype_grid', 'ViewName' => 'tpu_reports', 'WhereClause' => 'instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tpu_reportsid) as tpu_reportsid, B2G(tpu_reportsid) as id,B2G(instanceid) as instanceid, TPU_REPORTS_BRIEF_F(tpu_reportsid , NULL) as  brief,thefile,thefile_ext,B2G(ReportType) reporttype, TPD_REPORT_BRIEF_F(reporttype, NULL) as reporttype_grid', 'ViewName' => 'tpu_reports', 'WhereClause' => ' parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tpu_reports', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>