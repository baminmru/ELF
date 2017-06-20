<?php
	 class C_tplc_e extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLC_E.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLC_E.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplc_eid' =>  $this->input->get_post('tplc_eid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'dcall' =>   $this->input->get_post('dcall', TRUE)
                ,'dcounter' =>   $this->input->get_post('dcounter', TRUE)
                ,'e0' =>   $this->input->get_post('e0', TRUE)
                ,'e1' =>   $this->input->get_post('e1', TRUE)
                ,'e2' =>   $this->input->get_post('e2', TRUE)
                ,'e3' =>   $this->input->get_post('e3', TRUE)
                ,'e4' =>   $this->input->get_post('e4', TRUE)
                ,'e0s' =>   $this->input->get_post('e0s', TRUE)
                ,'e1s' =>   $this->input->get_post('e1s', TRUE)
                ,'e2s' =>   $this->input->get_post('e2s', TRUE)
                ,'e3s' =>   $this->input->get_post('e3s', TRUE)
                ,'e4s' =>   $this->input->get_post('e4s', TRUE)
                ,'ap' =>   $this->input->get_post('ap', TRUE)
                ,'am' =>   $this->input->get_post('am', TRUE)
                ,'rp' =>   $this->input->get_post('rp', TRUE)
                ,'rm' =>   $this->input->get_post('rm', TRUE)
                ,'i1' =>   $this->input->get_post('i1', TRUE)
                ,'i2' =>   $this->input->get_post('i2', TRUE)
                ,'i3' =>   $this->input->get_post('i3', TRUE)
                ,'u1' =>   $this->input->get_post('u1', TRUE)
                ,'u2' =>   $this->input->get_post('u2', TRUE)
                ,'u3' =>   $this->input->get_post('u3', TRUE)
                ,'oktime' =>   $this->input->get_post('oktime', TRUE)
                ,'worktime' =>   $this->input->get_post('worktime', TRUE)
                ,'errinfo' =>   $this->input->get_post('errinfo', TRUE)
            );
            $tplc_e = $this->m_tplc_e->setRow($data);
            print json_encode($tplc_e);
    }
    function newRow() {
            log_message('debug', 'TPLC_E.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplc_eid' =>  $this->input->get_post('tplc_eid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'dcall' =>   $this->input->get_post('dcall', TRUE)
                ,'dcounter' =>   $this->input->get_post('dcounter', TRUE)
                ,'e0' =>   $this->input->get_post('e0', TRUE)
                ,'e1' =>   $this->input->get_post('e1', TRUE)
                ,'e2' =>   $this->input->get_post('e2', TRUE)
                ,'e3' =>   $this->input->get_post('e3', TRUE)
                ,'e4' =>   $this->input->get_post('e4', TRUE)
                ,'e0s' =>   $this->input->get_post('e0s', TRUE)
                ,'e1s' =>   $this->input->get_post('e1s', TRUE)
                ,'e2s' =>   $this->input->get_post('e2s', TRUE)
                ,'e3s' =>   $this->input->get_post('e3s', TRUE)
                ,'e4s' =>   $this->input->get_post('e4s', TRUE)
                ,'ap' =>   $this->input->get_post('ap', TRUE)
                ,'am' =>   $this->input->get_post('am', TRUE)
                ,'rp' =>   $this->input->get_post('rp', TRUE)
                ,'rm' =>   $this->input->get_post('rm', TRUE)
                ,'i1' =>   $this->input->get_post('i1', TRUE)
                ,'i2' =>   $this->input->get_post('i2', TRUE)
                ,'i3' =>   $this->input->get_post('i3', TRUE)
                ,'u1' =>   $this->input->get_post('u1', TRUE)
                ,'u2' =>   $this->input->get_post('u2', TRUE)
                ,'u3' =>   $this->input->get_post('u3', TRUE)
                ,'oktime' =>   $this->input->get_post('oktime', TRUE)
                ,'worktime' =>   $this->input->get_post('worktime', TRUE)
                ,'errinfo' =>   $this->input->get_post('errinfo', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplc_e= $this->m_tplc_e->newRow($instanceid,$data);
            $return = $tplc_e;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLC_E.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplc_e = $this->m_tplc_e->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplc_e
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'dcall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplc_e= $this->m_tplc_e->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplc_e= $this->m_tplc_e->getRows($sort);
                }
            }else{
              $tplc_e= $this->m_tplc_e->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_e
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLC_E.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'dcall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplc_e= $this->m_tplc_e->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplc_e
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLC_E.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'dcall', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplc_e= $this->m_tplc_e->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplc_e
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLC_E.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplc_eid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplc_e->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tplc_e', 'm_tplc_e');
    }
}
?>