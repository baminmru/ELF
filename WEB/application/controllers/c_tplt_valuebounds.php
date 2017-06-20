<?php
	 class C_tplt_valuebounds extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_VALUEBOUNDS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_VALUEBOUNDS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_valueboundsid' =>  $this->input->get_post('tplt_valueboundsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'pname' =>   $this->input->get_post('pname', TRUE)
                ,'ptype' =>   $this->input->get_post('ptype', TRUE)
                ,'pmin' =>   $this->input->get_post('pmin', TRUE)
                ,'pmax' =>   $this->input->get_post('pmax', TRUE)
                ,'ismin' =>   $this->input->get_post('ismin', TRUE)
                ,'ismax' =>   $this->input->get_post('ismax', TRUE)
            );
            $tplt_valuebounds = $this->m_tplt_valuebounds->setRow($data);
            print json_encode($tplt_valuebounds);
    }
    function newRow() {
            log_message('debug', 'TPLT_VALUEBOUNDS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_valueboundsid' =>  $this->input->get_post('tplt_valueboundsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'pname' =>   $this->input->get_post('pname', TRUE)
                ,'ptype' =>   $this->input->get_post('ptype', TRUE)
                ,'pmin' =>   $this->input->get_post('pmin', TRUE)
                ,'pmax' =>   $this->input->get_post('pmax', TRUE)
                ,'ismin' =>   $this->input->get_post('ismin', TRUE)
                ,'ismax' =>   $this->input->get_post('ismax', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_valuebounds= $this->m_tplt_valuebounds->newRow($instanceid,$data);
            $return = $tplt_valuebounds;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_VALUEBOUNDS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_valuebounds = $this->m_tplt_valuebounds->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_valuebounds
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
            	$sort[] = array('property'=>'pname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_valuebounds= $this->m_tplt_valuebounds->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_valuebounds= $this->m_tplt_valuebounds->getRows($sort);
                }
            }else{
              $tplt_valuebounds= $this->m_tplt_valuebounds->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_valuebounds
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_VALUEBOUNDS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'pname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_valuebounds= $this->m_tplt_valuebounds->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_valuebounds
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
        log_message('debug', 'TPLT_VALUEBOUNDS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'pname', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_valuebounds= $this->m_tplt_valuebounds->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_valuebounds
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
        log_message('debug', 'TPLT_VALUEBOUNDS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_valueboundsid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_valuebounds->deleteRow($tempId);
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
        $this->load->model('M_tplt_valuebounds', 'm_tplt_valuebounds');
    }
}
?>