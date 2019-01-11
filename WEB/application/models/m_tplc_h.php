
<?php
class  M_tplc_h extends CI_Model {
    function getRow($empId) {
    $result = array('success' => false, 'msg' => 'No Row ID for retrive data');
	if (!empty($empId)){
	    $res = $this->jservice->get(array('Action' => 'GetRowData','FieldList'=>'B2G(tplc_hid) as tplc_hid, B2G(tplc_hid) as id,B2G(instanceid) as instanceid, TPLC_H_BRIEF_F(tplc_hid , NULL) as  brief,  DATE_FORMAT(dcall,\'%Y-%m-%d %H:%i:%s\') as  dcall,  DATE_FORMAT(dcounter,\'%Y-%m-%d %H:%i:%s\') as  dcounter,q1,q2,t1,t2,dt12,t3,t4,t5,dt45,t6,v1,v2,dv12,v3,v4,v5,dv45,v6,m1,m2,dm12,m3,m4,m5,dm45,m6,p1,p2,p3,p4,p5,p6,g1,g2,g3,g4,g5,g6,tcool,tce1,tce2,tsum1,tsum2,q1h,q2h,v1h,v2h,v4h,v5h,errtime,errtimeh,hc,sp,sp_tb1,sp_tb2,  DATE_FORMAT(datetimecounter,\'%Y-%m-%d %H:%i:%s\') as  datetimecounter,dg12,dg45,dp12,dp45,unitsr,q3,q4,patm,q5,dq12,dq45,pxb,dq,hc_1,hc_2,thot,dans1,dans2,dans3,dans4,dans5,dans6,check_a,oktime,worktime,tair1,tair2,hc_code', 'PartName' => 'tplc_h', 'ID' =>  $empId 	));
	    if (!empty($res)) {
	        $result = $res[0];
	    }
	}
	return $result;
    }
    function setRow($data)  {
	    $data = (array)$data;
	if (!empty($data)) {
	    if (empty($data['tplc_hid'])) {
	        $data['tplc_hid'] = $this->jservice->get(array('Action' => 'NewGuid'));
	        $res=$this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplc_h', 'RowID' => $data['tplc_hid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }else{
	    $res = $this->jservice->get(array('Action' => 'UpdateRow', 'PartName' => 'tplc_h', 'RowID' => $data['tplc_hid'], 'DocumentID' => $data['instanceid'], 'Values'=>$data));
	       if(isset($res[0])){
	       	if($res[0]->result!='ok'){
	       		return array('success' => FALSE, 'msg' => $res[0]->result);
	       	} 
	       }else{
	       	return array('success' => FALSE, 'msg' => 'Unknown error' );
	       }
	    }
	    return array('success' => TRUE, 'data' => $this->getRow($data['tplc_hid'] ));
	} else {
	    return array('success' => FALSE, 'msg' => 'No data to store on server');
	}
    }
    function newRow($instanceid,$data)  {
	  $id = $this->jservice->get(array('Action' => 'NewGuid'));
	if ($this->jservice->get(array('Action' => 'NewRow', 'PartName' => 'tplc_h', 'RowID' => $id, 'DocumentID' => $instanceid, 'Values'=>$data)) == 'OK') {
	    return array('success' => TRUE, 'data' => $id);
	} else {
	    return array('success' => FALSE, 'msg' => 'Error while create new id');
	}
    }
    function getRows($sort=array())
		{
	    $res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplc_hid) as tplc_hid, B2G(tplc_hid) as id,B2G(instanceid) as instanceid, TPLC_H_BRIEF_F(tplc_hid , NULL) as  brief,  DATE_FORMAT(dcall,\'%Y-%m-%d %H:%i:%s\') as  dcall,  DATE_FORMAT(dcounter,\'%Y-%m-%d %H:%i:%s\') as  dcounter,q1,q2,t1,t2,dt12,t3,t4,t5,dt45,t6,v1,v2,dv12,v3,v4,v5,dv45,v6,m1,m2,dm12,m3,m4,m5,dm45,m6,p1,p2,p3,p4,p5,p6,g1,g2,g3,g4,g5,g6,tcool,tce1,tce2,tsum1,tsum2,q1h,q2h,v1h,v2h,v4h,v5h,errtime,errtimeh,hc,sp,sp_tb1,sp_tb2,  DATE_FORMAT(datetimecounter,\'%Y-%m-%d %H:%i:%s\') as  datetimecounter,dg12,dg45,dp12,dp45,unitsr,q3,q4,patm,q5,dq12,dq45,pxb,dq,hc_1,hc_2,thot,dans1,dans2,dans3,dans4,dans5,dans6,check_a,oktime,worktime,tair1,tair2,hc_code', 'ViewName' => 'tplc_h','WhereClause' => ' dcounter >DATE_SUB(NOW(),INTERVAL 3 DAY)')));
	    if (count($res)) {
	        return $res;
	    } else {
	        return null;
	    }
		}
    function getRowsByInstance($id,$sort=array())
		{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplc_hid) as tplc_hid, B2G(tplc_hid) as id,B2G(instanceid) as instanceid, TPLC_H_BRIEF_F(tplc_hid , NULL) as  brief,  DATE_FORMAT(dcall,\'%Y-%m-%d %H:%i:%s\') as  dcall,  DATE_FORMAT(dcounter,\'%Y-%m-%d %H:%i:%s\') as  dcounter,q1,q2,t1,t2,dt12,t3,t4,t5,dt45,t6,v1,v2,dv12,v3,v4,v5,dv45,v6,m1,m2,dm12,m3,m4,m5,dm45,m6,p1,p2,p3,p4,p5,p6,g1,g2,g3,g4,g5,g6,tcool,tce1,tce2,tsum1,tsum2,q1h,q2h,v1h,v2h,v4h,v5h,errtime,errtimeh,hc,sp,sp_tb1,sp_tb2,  DATE_FORMAT(datetimecounter,\'%Y-%m-%d %H:%i:%s\') as  datetimecounter,dg12,dg45,dp12,dp45,unitsr,q3,q4,patm,q5,dq12,dq45,pxb,dq,hc_1,hc_2,thot,dans1,dans2,dans3,dans4,dans5,dans6,check_a,oktime,worktime,tair1,tair2,hc_code', 'ViewName' => 'tplc_h', 'WhereClause' => '  dcounter >DATE_SUB(NOW(),INTERVAL 3 DAY) and instanceid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
		}
    function getRowsByParent($id,$sort=array())
	{
	$res = $this->jservice->get(array('Action' => 'GetViewData','Sort'=>$sort,'FieldList'=>'B2G(tplc_hid) as tplc_hid, B2G(tplc_hid) as id,B2G(instanceid) as instanceid, TPLC_H_BRIEF_F(tplc_hid , NULL) as  brief,  DATE_FORMAT(dcall,\'%Y-%m-%d %H:%i:%s\') as  dcall,  DATE_FORMAT(dcounter,\'%Y-%m-%d %H:%i:%s\') as  dcounter,q1,q2,t1,t2,dt12,t3,t4,t5,dt45,t6,v1,v2,dv12,v3,v4,v5,dv45,v6,m1,m2,dm12,m3,m4,m5,dm45,m6,p1,p2,p3,p4,p5,p6,g1,g2,g3,g4,g5,g6,tcool,tce1,tce2,tsum1,tsum2,q1h,q2h,v1h,v2h,v4h,v5h,errtime,errtimeh,hc,sp,sp_tb1,sp_tb2,  DATE_FORMAT(datetimecounter,\'%Y-%m-%d %H:%i:%s\') as  datetimecounter,dg12,dg45,dp12,dp45,unitsr,q3,q4,patm,q5,dq12,dq45,pxb,dq,hc_1,hc_2,thot,dans1,dans2,dans3,dans4,dans5,dans6,check_a,oktime,worktime,tair1,tair2,hc_code', 'ViewName' => 'tplc_h', 'WhereClause' => ' dcounter >DATE_SUB(NOW(),INTERVAL 3 DAY) and parentstructrowid=G2B(\''. $id . '\')'));
	if (count($res) == 0) {
	    return null;
	} else {
	    return $res;
	}
  }
    function deleteRow($id = null) {
	  if (!empty($id) && $this->jservice->get(array('Action' => 'DeleteRow', 'PartName' => 'tplc_h', 'RowID' => $id)) == 'OK')
	    $result = array('success' => TRUE);
	else
	    $result = array('success' => FALSE, 'msg' => 'Error while deleting record!');
	return $result;
    }
}
?>