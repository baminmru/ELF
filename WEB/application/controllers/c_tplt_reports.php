<?php
	 class C_tplt_reports extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLT_REPORTS.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLT_REPORTS.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tplt_reportsid' =>  $this->input->get_post('tplt_reportsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'reptype' =>   $this->input->get_post('reptype', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'thefile' =>   $this->input->get_post('thefile', TRUE)
                ,'thefile_ext' =>   $this->input->get_post('thefile_ext', TRUE)
            );
            $tplt_reports = $this->m_tplt_reports->setRow($data);
            print json_encode($tplt_reports);
    }
    function newRow() {
            log_message('debug', 'TPLT_REPORTS.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tplt_reportsid' =>  $this->input->get_post('tplt_reportsid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'reptype' =>   $this->input->get_post('reptype', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
                ,'thefile' =>   $this->input->get_post('thefile', TRUE)
                ,'thefile_ext' =>   $this->input->get_post('thefile_ext', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tplt_reports= $this->m_tplt_reports->newRow($instanceid,$data);
            $return = $tplt_reports;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLT_REPORTS.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tplt_reports = $this->m_tplt_reports->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tplt_reports
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
            	$sort[] = array('property'=>'reptype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tplt_reports= $this->m_tplt_reports->getRowsByInstance($instanceid,$sort);
                }else{
                    $tplt_reports= $this->m_tplt_reports->getRows($sort);
                }
            }else{
              $tplt_reports= $this->m_tplt_reports->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_reports
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLT_REPORTS.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'reptype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tplt_reports= $this->m_tplt_reports->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tplt_reports
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
        log_message('debug', 'TPLT_REPORTS.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'reptype', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tplt_reports= $this->m_tplt_reports->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tplt_reports
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
        log_message('debug', 'TPLT_REPORTS.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tplt_reportsid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tplt_reports->deleteRow($tempId);
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
        $this->load->model('M_tplt_reports', 'm_tplt_reports');
    }
}
?>